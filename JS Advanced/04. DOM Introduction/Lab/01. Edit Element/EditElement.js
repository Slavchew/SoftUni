function editElement(ref, match, replacer) {
    const text = ref.textContent;
    const matcher = RegExp(match, 'g')
    ref.textContent = text.replace(matcher, replacer);
}