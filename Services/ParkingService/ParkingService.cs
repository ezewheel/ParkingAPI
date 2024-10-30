using Common.DTOs.ParkingDTOs;
using Data.Entities;
using Data.Repositories.ParkingRepository;
using Services.FeesService;

namespace Services.ParkingService
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository _parkingRepository;
        private readonly IFeesService _feesService;
        private readonly ISlotsRepository _slotsRepository;

        public ParkingService(IParkingRepository parkingRepository, IFeesService feesService , ISlotsRepository slotsRepository)
        {
            _parkingRepository = parkingRepository;
            _feesService = feesService;
            _slotsRepository = slotsRepository;
        }

        public List<ParkingForViewDto> Get()
        {
            List<Parking> parkings = _parkingRepository.Get();
            return parkings.Select(parking => new ParkingForViewDto
            {
                Plate = parking.Plate,
                SlotId = parking.SlotId,
                EntryTime = parking.EntryTime,
                ExitTime = parking.ExitTime,
                Fee = parking.Fee
            }).ToList();
        }

        public void Add(ParkingForAddDto parkingForAdd)
        {
            _parkingRepository.Add(new Parking
            {
                SlotId = parkingForAdd.SlotId,
                Plate = parkingForAdd.Plate,
                EntryTime = DateTime.UtcNow,
                ExitTime = null,
                Fee = null
            });

            Slot? slot = _slotsRepository.Get().FirstOrDefault(s => s.Id == parkingForAdd.SlotId);
            _slotsRepository.Modify(new Slot
            {
                Id = slot.Id,
                Description = slot.Description,
                IsAvailable = false
            });
        }

        public ParkingForViewDto? Close(string plate)
        {
            Parking? parking = _parkingRepository.Get(plate);
            if (parking is null)
            {
                return null;
            }

            DateTime exitTime = DateTime.UtcNow;
            parking.ExitTime = exitTime;
            parking.Fee = _feesService.GetFee(parking.EntryTime, exitTime);

            _parkingRepository.Modify(parking);
            Slot? slot = _slotsRepository.Get().FirstOrDefault(s => s.Id == parking.SlotId);
            _slotsRepository.Modify(new Slot
            {
                Id = slot.Id,
                Description = slot.Description,
                IsAvailable = true
            });

            return new ParkingForViewDto
            {
                Plate = parking.Plate,
                SlotId = parking.SlotId,
                EntryTime = parking.EntryTime,
                ExitTime = parking.ExitTime,
                Fee = parking.Fee
            };
        }
    }
}