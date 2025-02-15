using AutoMapper;
using DataAccess.Repository.IRepository;
using DTOS.CropDataDTO;
using DTOS.SoilDataDTO;
using Microsoft.AspNetCore.Mvc;

namespace FarmWiseAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SoilDataController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public SoilDataController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.mapper=mapper;
        this.unitOfWork=unitOfWork;
    }



    [HttpGet("{id:guid}", Name = "GetSingleCropAsync")]
    public async Task<IActionResult> GetSingleSoilDataAsync(Guid id)
    {
        var SoilDataDomain = await unitOfWork.SoilDatas.Get(a => a.Id==id);
        if (SoilDataDomain==null)
        {
            return NotFound("Crop Data is Not Found!");
        }
        //var soilDataDTO = new SoilDataDTOs()
        var soilDataDTO = mapper.Map<SoilDataDTOs>(SoilDataDomain);
        return Ok(soilDataDTO);
    }


    [HttpGet]
    public async Task<IActionResult> GetAllSiolData()
    {
        var soilData = await unitOfWork.SoilDatas.GetAll();

        if (soilData==null)
        {
            return NotFound("Soil Data Not Found!");
        }

        var soilDataDTOs = mapper.Map<List<SoilDataDTOs>>(soilData);
        return Ok(soilDataDTOs);
    }


    [HttpPost]
    public async Task<IActionResult> AddSoilDataAsync([FromBody] AddSoilDataRequest addSoilDataRequest)
    {
        if (addSoilDataRequest==null)
        {
            return NotFound("Crop Can't Add");
        }

        var soilData = mapper.Map<SoilData>(addSoilDataRequest);
        await unitOfWork.SoilDatas.Add(soilData);
        await unitOfWork.Save();

        var soilDataDTO = mapper.Map<SoilDataDTOs>(soilData);
        return Ok(soilDataDTO);
    }


    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteSoilData(Guid id)
    {
        var soilData = await unitOfWork.SoilDatas.Get(a => a.Id==id);
        if (soilData==null)
        {
            return NotFound("Soil Data Not Found!");
        }

        var soilDataDTO = mapper.Map<SoilDataDTOs>(soilData);

        unitOfWork.SoilDatas.Remove(soilData);
        await unitOfWork.Save();

        return Ok(soilDataDTO);
    }


    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdataSoilData(Guid id, [FromBody] UpdataSoilDataRequest updataSoilDataRequest)
    {
        var soilData = await unitOfWork.SoilDatas.Get(a => a.Id==id);

        if (soilData==null)
        {
            return NotFound("this Soil Data not Found!");
        }
        soilData.Id=id;
        soilData.Location=updataSoilDataRequest.Location;
        soilData.PHLevel=updataSoilDataRequest.PHLevel;
        soilData.SoilMoisture=updataSoilDataRequest.SoilMoisture;
        soilData.Crops=soilData.Crops;

        unitOfWork.SoilDatas.Update(soilData);
        await unitOfWork.Save();

        var soilDataDTO = mapper.Map<SoilDataDTOs>(soilData);

        return Ok(soilDataDTO);
    }
}

