namespace MPS.DataAccess.Entities
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
