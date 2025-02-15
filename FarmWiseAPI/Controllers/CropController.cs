using AutoMapper;
using DataAccess.Repository.IRepository;
using DTOS.CropDTOs;
using Microsoft.AspNetCore.Mvc;
using Model;


namespace FarmWiseAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CropController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public CropController(IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.mapper=mapper;
        this.unitOfWork=unitOfWork;
    }


    [HttpGet("{id:guid}", Name = "GetCropbyIdAsync")]
    public async Task<IActionResult> GetCropbyIdAsync(Guid id)
    {
        var cropDomain = await unitOfWork.Crops.Get(u => u.CropID == id);
        if (cropDomain==null)
        {
            return NotFound("Crop Not Found");
        }
        var cropDTO = mapper.Map<Crop>(cropDomain);

        return Ok(cropDTO);
    }


    [HttpGet]
    public async Task<IActionResult> GetAllCropsAsync()
    {
        var cropDomain = await unitOfWork.Crops.GetAll();
        if (cropDomain==null)
        {
            return NotFound("Crops Not Found ");
        }
        var cropsDTO = mapper.Map<List<CropDTO>>(cropDomain);
        return Ok(cropsDTO);
    }


    [HttpPost]
    public async Task<IActionResult> AddCropAsync([FromBody] AddCropRequest addCropRequest)
    {
        if (addCropRequest == null)
        {
            return NotFound("this Crop Empty");
        }
        var cropDomain = mapper.Map<Crop>(addCropRequest);

        await unitOfWork.Crops.Add(cropDomain);
        await unitOfWork.Save();

        var cropDTO = mapper.Map<Crop>(cropDomain);

        return Ok(cropDTO);
    }


    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCropasync(Guid id)
    {
        var CropDomain = await unitOfWork.Crops.Get(c => c.CropID==id);
        if (CropDomain==null)
        {
            return NotFound("Crop not Found");
        }
        var cropDTO = mapper.Map<CropDTO>(CropDomain);

        unitOfWork.Crops.Remove(CropDomain);
        await unitOfWork.Save();
        return Ok(cropDTO);
    }



    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdataCropsAsync(Guid id, [FromBody] UpdataCropsRequest updataCropsRequest)
    {
        var CropDomain = await unitOfWork.Crops.Get(a => a.CropID==id);
        if (CropDomain==null)
        {
            return NotFound("Crop domain Not Found");
        }

        CropDomain.CropID=id;
        CropDomain.CropName=updataCropsRequest.CropName;
        CropDomain.CropType=updataCropsRequest.CropType;
        CropDomain.Fertilizers=updataCropsRequest.Fertilizers;
        CropDomain.HarvestDate=updataCropsRequest.HarvestDate;
        CropDomain.Pesticides=updataCropsRequest.Pesticides;
        CropDomain.PlantDate=updataCropsRequest.PlantDate;
        CropDomain.SoilDataId=updataCropsRequest.SoilDataId;
        CropDomain.UserId=updataCropsRequest.UserId;

        unitOfWork.Crops.Update(CropDomain);
        await unitOfWork.Save();

        var cropDTO = mapper.Map<CropDTO>(CropDomain);
        return Ok(cropDTO);
    }
}
