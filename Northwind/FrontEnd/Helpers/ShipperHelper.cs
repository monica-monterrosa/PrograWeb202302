using FrontEnd.Models;
using Newtonsoft.Json;
namespace FrontEnd.Helpers
{
    public class ShipperHelper
    {
        ServiceRepository repository;

        public ShipperHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL

        public List<ShipperViewModel> GetAll()
        {



            List<ShipperViewModel> lista = new List<ShipperViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Shipper/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ShipperViewModel>>(content);

            }




            return lista;
        }
        #endregion


        #region GetByID

        /// <summary>
        /// Obtener Shipper por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShipperViewModel GetByID(int id)
        {
            ShipperViewModel Shipper = new ShipperViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Shipper/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            Shipper = JsonConvert.DeserializeObject<ShipperViewModel>(content);

            return Shipper;

        }



        #endregion
    }
}
