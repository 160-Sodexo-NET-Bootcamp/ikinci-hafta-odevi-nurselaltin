using DataAccess.UnityOfWork;
using Entity.Concrete;
using GarbageCollectSystemAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GarbageCollectSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnityOfWork _unityOfWork;

        public VehicleController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        /// <summary>
        /// Get all vehicles.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            //Get vehicles
            var vehicles = _unityOfWork.VehicleRepository.GetAll();

            //Fill the view model
            var models = new List<VehicleModel>();

            if (vehicles.Count() > 0)
              {
                  foreach (var item in vehicles)
                  {
                    var model = new VehicleModel();
                    model.VehicleName = item.VehicleName;
                    model.VehiclePlate = item.VehiclePlate;

                    models.Add(model);  
                  }
              }

            return Ok(models);
        }

        /// <summary>
        /// Add new vehicle.
        /// </summary>
        /// <param name="model">The model type is  Vehicle  model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] VehicleModel model)
        {
            //Control the new model
            if (model is null)
                return Ok("Please , input the book information.You can not send empty model.");

            //ViewModel >> Entity
            Vehicle vehicle = new Vehicle();
            vehicle.VehicleName = model.VehicleName;
            vehicle.VehiclePlate = model.VehiclePlate;

            //Add new vehicle
            _unityOfWork.VehicleRepository.Add(vehicle, true);

            //Get vehicle list with added new vehicle
            var vehicles = _unityOfWork.VehicleRepository.GetAll();

            //Fill the view model
            var models = new List<VehicleModel>();

            if (vehicles.Count() > 0)
            {
                foreach (var item in vehicles)
                {
                    var vehicleModel = new VehicleModel();
                    vehicleModel.VehicleName = item.VehicleName;
                    vehicleModel.VehiclePlate = item.VehiclePlate;

                    models.Add(vehicleModel);
                }
            }

            return Ok(models);
        }

        /// <summary>
        /// Update vehicle of ID. Get the id value with FromRoute.
        /// </summary>
        /// <param name="model">The model type is  Vehicle model.</param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] VehicleModel model, int id)
        {
            //Prepare  response message
            var res = true;

            //Get vehicle list
            var vehicles = _unityOfWork.VehicleRepository.GetAll().ToList();

            //Control the id 
            if (id == 0)
                res = false;

            //Is container exist?
            var container = vehicles.FirstOrDefault(x => x.VehicleID == id);
            if (container is null)
                res = false;

            //return BadRequest
            if (!res)
            {
                return BadRequest("Something wrong!Check your vehicle informations.");
            }

            //Update vehicle
            var vehicle = vehicles.FirstOrDefault(x => x.VehicleID == id);
            vehicle.VehicleName = model.VehicleName;
            vehicle.VehiclePlate = model.VehiclePlate;

            _unityOfWork.VehicleRepository.Update(vehicle, true);
            return Ok(vehicle);
        }

        /// <summary>
        /// Delete vehicle of id. Get the id value with FromRoute
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Prepare  response message
            var res = true;

            //Control the id 
            if (id == 0)
                res = false;

            //Is vehicle exist?
            var vehicle = _unityOfWork.VehicleRepository.GetByID(id); 
            if (vehicle is null)
                res = false;

            //return BadRequest
            if (!res)
            {
                return BadRequest("Something wrong!Check your vehicle informations.");
            }

            //Remove vehicle
            _unityOfWork.VehicleRepository.Delete(vehicle.VehicleID, true);

            //Get updated vehicles List
            var vehicles = _unityOfWork.VehicleRepository.GetAll();

            //Fill the view model
            var models = new List<VehicleModel>();

            if (vehicles.Count() > 0)
            {
                foreach (var item in vehicles)
                {
                    var vehicleModel = new VehicleModel();
                    vehicleModel.VehicleName = item.VehicleName;
                    vehicleModel.VehiclePlate = item.VehiclePlate;

                    models.Add(vehicleModel);
                }
            }

            return Ok(models);
        }
    }
}
