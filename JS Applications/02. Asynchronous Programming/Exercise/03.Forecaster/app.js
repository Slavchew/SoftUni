async function attachEvents() {
    const locationInput = document.getElementById('location');
    const getWeatherBtn = document.getElementById('submit');
    const forecastDiv = document.getElementById('forecast');
    const currentDiv = document.getElementById('current');
    const upcomingDiv = document.getElementById('upcoming');

    const symbols = {
        'Sunny': "&#x2600;",
        'Partly sunny': "&#x26C5;",
        'Overcast': "&#x2601;",
        'Rain': "&#x2614;",
        'Degrees': "&#176;",
    }

    const locationsRes = await fetch('http://localhost:3030/jsonstore/forecaster/locations');
    const locationsData = await locationsRes.json();

    getWeatherBtn.addEventListener('click', async function () {
        const locationName = locationInput.value;

        try {
            const code = Object.values(locationsData).find(l => l.name.toLowerCase() === locationName.toLowerCase()).code;
            const currConditionRes = await fetch(`http://localhost:3030/jsonstore/forecaster/today/${code}`);
            console.log(currConditionRes);
            if (currConditionRes.status != 200) {
                throw new Error('The is no forecast for the given location');
            }
            const currConditionData = await currConditionRes.json();
    
            forecastDiv.style.display = 'block';
    
            currentDiv.innerHTML = '<div class="label">Current conditions</div>';
            setCurrentForecast(currConditionData);
    
            const threeDaysConditionRes = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${code}`);
            if (threeDaysConditionRes.status != 200) {
                throw new Error('The is no forecast for the given location');
            }
            const threeDaysConditionData = await threeDaysConditionRes.json();
            
            upcomingDiv.style.display = 'block';
            upcomingDiv.innerHTML = '<div class="label">Three-day forecast</div>';
            setUpcomingForecast(threeDaysConditionData);
        } catch (error) {
            forecastDiv.style.display = 'block';
            currentDiv.innerHTML = '<div class="label">Error</div>';
            upcomingDiv.style.display = 'none';
        } 
    })

    function setUpcomingForecast(threeDaysConditionData) {
        const forecastInfoDiv = document.createElement('div');
        forecastInfoDiv.classList.add('forecast-info');

        for (const { condition, high, low } of threeDaysConditionData.forecast) {
            const upcomingForecastSpan = document.createElement('span');
            upcomingForecastSpan.classList.add('upcoming');

            const symbolSpan = document.createElement('span');
            symbolSpan.classList.add('symbol');
            symbolSpan.innerHTML = symbols[condition];

            upcomingForecastSpan.appendChild(symbolSpan);

            upcomingForecastSpan.appendChild(
                createForecastDataSpan(`${low}${symbols['Degrees']}/${high}${symbols['Degrees']}`));
            upcomingForecastSpan.appendChild(createForecastDataSpan(condition));

            forecastInfoDiv.appendChild(upcomingForecastSpan);
        }

        upcomingDiv.appendChild(forecastInfoDiv);
    }

    function setCurrentForecast(currConditionData) {
        const currConditionSym = symbols[currConditionData.forecast.condition];

        const currForecastDiv = document.createElement('div');
        currForecastDiv.classList.add('forecasts');

        const symbolSpan = document.createElement('span');
        symbolSpan.classList.add('condition', 'symbol');
        symbolSpan.innerHTML = currConditionSym;

        currForecastDiv.appendChild(symbolSpan);

        const currForecastSpan = document.createElement('span');
        currForecastSpan.classList.add('condition');
        currForecastSpan.appendChild(createForecastDataSpan(currConditionData.name));
        currForecastSpan.appendChild(
            createForecastDataSpan(`${currConditionData.forecast.low}${symbols['Degrees']}/${currConditionData.forecast.high}${symbols['Degrees']}`));
        currForecastSpan.appendChild(createForecastDataSpan(currConditionData.forecast.condition));

        currForecastDiv.appendChild(currForecastSpan);

        currentDiv.appendChild(currForecastDiv);
    }

    function createForecastDataSpan(data) {
        const span = document.createElement('span');
        span.classList.add('forecast-data');
        span.innerHTML = data;
        return span;
    }
}

attachEvents();