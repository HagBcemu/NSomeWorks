namespace NSomeWorks
{
    class Product
    {
        private string _nameProduct;

        private int _priseProduct;

        public Product(string nameProduct, int priseProduct)
        {
            _nameProduct = nameProduct;
            _priseProduct = priseProduct;
        }

        public string Name
        {
            get { return _nameProduct; }
        }

        public int Prise
        {
            get { return _priseProduct; }
        }
    }
}
