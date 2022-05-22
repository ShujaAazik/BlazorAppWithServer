namespace UserManagement___FrontEnd.View_Models
{
    public class ContractConfigRM
    {
        public bool Succeeded { get; set; }

        public string Content { get; set; }

        public string Message { get; set; }

        public ContractConfigRM(bool Succeeded, string Message)
        {
            this.Succeeded = Succeeded;
            this.Message = Message; 
        }
    }
}
