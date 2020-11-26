namespace TechnicalSolution.EL.Configurations
{
    /// <summary>
    /// Datatype to return the information
    /// </summary>
    /// <typeparam name="TEntity">Datatyte to process</typeparam>
    public class BusinessValue<TEntity>
    {
        public BusinessValue()
        {
        }

        public BusinessValue(string message, Status status)
        {
            Message = message;
            Status = status;
        }

        public BusinessValue(TEntity data, Status status)
        {
            Data = data;
            Status = status;
        }

        public BusinessValue(TEntity data, string message, Status status)
        {
            Data = data;
            Status = status;
            Message = message;
        }

        public TEntity Data { get; set; }
        public Status Status { get; set; }
        public string Message { get; set; }
    }
}
