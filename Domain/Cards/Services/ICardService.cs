namespace Domain.Cards.Services
{
    public interface ICardService
    {
        byte[] GetImage(int multiverseId);
        void CreateCard(CreateCardRequest request);
    }
}
