using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {

        private IShipperDAL ShipperDAL;

        private ShipperModel Convertir(Shipper Shipper)
        {
            return new ShipperModel
            {
                ShipperId = Shipper.ShipperId,
                CompanyName = Shipper.CompanyName,
                Phone = Shipper.Phone
            };
        }



        private Shipper Convertir(ShipperModel Shipper)
        {
            return new Shipper
            {
                ShipperId = Shipper.ShipperId,
                CompanyName = Shipper.CompanyName,
                Phone = Shipper.Phone
            };
        }


        #region Constructores

        public ShipperController()
        {
            ShipperDAL = new ShipperDALImpl();

        }

        #endregion


        #region Consultas

        // GET: api/<ShipperController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Shipper> shippers = ShipperDAL.GetAll();
            List<ShipperModel> models = new List<ShipperModel>();

            foreach (var Shipper in shippers)
            {

                models.Add(Convertir(Shipper));

            }

            return new JsonResult(models);
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Shipper Shipper = ShipperDAL.Get(id);


            return new JsonResult(Convertir(Shipper));
        }
        #endregion

        #region Agregar


        // POST api/<ShipperController>
        [HttpPost]
        public JsonResult Post([FromBody] ShipperModel Shipper)
        {

            ShipperDAL.Add(Convertir(Shipper));
            return new JsonResult(Shipper);
        }

        #endregion

        #region Modificar


        // PUT api/<ShipperController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ShipperModel Shipper)
        {
            ShipperDAL.Update(Convertir(Shipper));
            return new JsonResult(Shipper);
        }
        #endregion


        #region Eliminar
        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Shipper Shipper = new Shipper
            {
                ShipperId = id
            };

            ShipperDAL.Remove(Shipper);

        }

        #endregion

    }
}