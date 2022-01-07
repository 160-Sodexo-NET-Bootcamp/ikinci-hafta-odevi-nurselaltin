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
    public class ContainerController : ControllerBase
    {
        private readonly IUnityOfWork _unityOfWork;

        public ContainerController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        /// <summary>
        /// Get all containers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            //Get containers
            var containers = _unityOfWork.ContainerRepository.GetAll();

            //Fill the view model
            var models = new List<ContainerModel>();

            if (containers.Count() > 0)
            {
                foreach (var item in containers)
                {
                    var model = new ContainerModel();
                    model.ContainerName = item.ContainerName;
                    model.Latitude = item.Latitude;
                    model.Longitude = item.Longitude;
                    model.VehicleID = item.VehicleID;

                    models.Add(model);
                }
            }
            return Ok(containers);
        }

        /// <summary>
        /// Get containers of vehicle
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetVehicleContainers")]
        public IActionResult GetAll([FromQuery] int vehicleID)
        {
            //Get containers of vehicle
            var containers = _unityOfWork.ContainerRepository.GetAll(x => x.VehicleID == vehicleID);
            
            //Fill the view model
            var models = new List<ContainerModel>();

            if (containers.Count() > 0)
            {
                foreach (var item in containers)
                {
                    var model = new ContainerModel();
                    model.ContainerName = item.ContainerName;
                    model.Latitude = item.Latitude;
                    model.Longitude = item.Longitude;
                    model.VehicleID = item.VehicleID;

                    models.Add(model);
                }
            }

            return Ok(models);
        }

        /// <summary>
        /// Add new container.
        /// </summary>
        /// <param name="model">The model type is  Container  model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] ContainerModel model)
        {
            //Control the new model
            if (model is null)
                return Ok("Please , input the container information.You can not send empty model.");

            //Control the  Vehicle 
            var vehicle = _unityOfWork.VehicleRepository.GetByID(model.VehicleID);
            if(vehicle == null)
                return Ok("Please , input the vehicle information.You can not send empty model.");

            //Add new container
            var container = new Container();
            container.ContainerName = model.ContainerName;
            container.Latitude = model.Latitude;
            container.Longitude = model.Longitude;
            container.VehicleID = model.VehicleID;

            _unityOfWork.ContainerRepository.Add(container, true);

            //Get container list with added new container
            var containers = _unityOfWork.ContainerRepository.GetAll();

            //Fill the view model
            var models = new List<ContainerModel>();

            if (containers.Count() > 0)
            {
                foreach (var item in containers)
                {
                    var containerModel = new ContainerModel();
                    containerModel.ContainerName = item.ContainerName;
                    containerModel.Latitude = item.Latitude;
                    containerModel.Longitude = item.Longitude;
                    containerModel.VehicleID = item.VehicleID;

                    models.Add(containerModel);
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
        public IActionResult Put([FromBody] ContainerModel model, int id)
        {
            //Prepare  response message
            var res = true;

            //Get vehicle list
            var containers = _unityOfWork.ContainerRepository.GetAll();

            //Control the id 
            if (id == 0)
                res = false;

            //Is container exist?
            var container = containers.FirstOrDefault(x => x.ContainerID == id);
            if (container is null)
                res = false;

            //return BadRequest
            if (!res)
            {
                return BadRequest("Something wrong!Check your container informations.");
            }

            //Update container
            container.ContainerName = model.ContainerName;
            container.Latitude = model.Latitude;
            container.Longitude = model.Longitude;

            _unityOfWork.ContainerRepository.Update(container, true);

            return Ok(container);
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

            //Is container exist?
            var container = _unityOfWork.ContainerRepository.GetByID(id);

            if (container is null)
                res = false;

            //return BadRequest
            if (!res)
            {
                return BadRequest("Something wrong!Check your container informations.");
            }

            //Remove vehicle
            _unityOfWork.ContainerRepository.Delete(id, true);

            //Get updated container list
            var containers = _unityOfWork.ContainerRepository.GetAll();

            //Fill the view model
            var models = new List<ContainerModel>();

            if (containers.Count() > 0)
            {
                foreach (var item in containers)
                {
                    var containerModel = new ContainerModel();
                   
                    containerModel.ContainerName = item.ContainerName;
                    containerModel.Latitude = item.Latitude;
                    containerModel.Longitude = item.Longitude;
                    containerModel.VehicleID = item.VehicleID;

                    models.Add(containerModel);
                }
            }
 
            return Ok(models);
        }
    }
}
