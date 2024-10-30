using Common.DTOs.ParkingDTOs;

namespace Services.ParkingService
{
    public interface IParkingService
    {
        List<ParkingForViewDto> Get();
        void Add(ParkingForAddDto parkingForAdd);
        ParkingForViewDto? Close(string plate);
    }
}
