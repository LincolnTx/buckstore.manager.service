namespace buckstore.manager.service.environment.Configuration
{
    public class KafkaConfiguration
    {
        public string ConnectionString { get; set; }
        public string Group { get; set; }
        public string ManagerToProductsCreate { get; set; }
        public string ManagerToProductsUpdate { get; set; }
        public string ManagerToProductsDelete { get; set; }
        public string ManagerToOrdersCreate { get; set; }
        public string ManagerToOrdersUpdate { get; set; }
        public string ManagerToOrdersDelete { get; set; }
        public string OrdersToManager { get; set; }
        public string ManagerStockUpdate { get; set; }
    }
}
