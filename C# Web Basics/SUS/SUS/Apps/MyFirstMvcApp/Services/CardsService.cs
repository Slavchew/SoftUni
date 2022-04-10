using System.Collections.Generic;
using System.Linq;

using BattleCards.Data;
using BattleCards.ViewModels.Cards;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCard(AddCardInputModel input)
        {
            var card = new Card
            {
                Name = input.Name,
                Attack = input.Attack,
                Health = input.Health,
                Description = input.Description,
                ImageUrl = input.Image,
                Keyword = input.Keyword
            };

            this.db.Cards.Add(card);
            this.db.SaveChanges();

            return card.Id;
        }

        public IEnumerable<CardViewModel> GetAll()
        {
            return this.db.Cards.Select(x => new CardViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Type = x.Keyword
            }).ToList();
        }

        public IEnumerable<CardViewModel> GetByUserId(string userId)
        {
            return this.db.UserCards.Where(x => x.UserId == userId)
                .Select(x => new CardViewModel
                {
                    Id = x.Card.Id,
                    ImageUrl = x.Card.ImageUrl,
                    Name = x.Card.Name,
                    Description = x.Card.Description,
                    Type = x.Card.Keyword,
                    Attack = x.Card.Attack,
                    Health = x.Card.Health,
                }).ToList();
        }

        public void AddCardToUserCollection(string usedId, int cardId)
        {
            if (this.db.UserCards.Any(x => x.UserId == usedId && x.CardId == cardId))
            {
                return;
            }

            this.db.UserCards.Add(new UserCard
            {
                UserId = usedId,
                CardId = cardId
            });

            this.db.SaveChanges();
        }

        public void RemoveCardFromUserCollection(string usedId, int cardId)
        {
            var userCard = this.db.UserCards.FirstOrDefault(x => x.UserId == usedId && x.CardId == cardId);

            if (userCard == null)
            {
                return;
            }

            this.db.UserCards.Remove(userCard);
            this.db.SaveChanges();
        }
    }
}
