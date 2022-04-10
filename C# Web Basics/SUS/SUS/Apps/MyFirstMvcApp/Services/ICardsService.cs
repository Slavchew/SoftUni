using System.Collections.Generic;

using BattleCards.ViewModels.Cards;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        int AddCard(AddCardInputModel model);

        IEnumerable<CardViewModel> GetAll();

        IEnumerable<CardViewModel> GetByUserId(string userId);

        void AddCardToUserCollection(string usedId, int cardId);
        void RemoveCardFromUserCollection(string usedId, int cardId);
    }
}
