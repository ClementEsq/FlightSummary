using FlightSummary.Service;
using FlightSummary.Service.Interface;
using Moq;
using NUnit.Framework;

/*
 * In an ideal scenario I would write unit tests for all the services generating a value 
 * for my output file. Due to time I've written this one test class which specifically
 * covers the FlightValidationService class to demonstrate TDD.
 */

namespace FlightSummary.Tests
{
    [TestFixture, Category("Unit test")]
    public class FlightValidationServiceTests
    {
        private IFlightValidationService _flightValidationService;
        private Mock<ICashFlowCalculationService> _cashFlowCalculationServiceMock;
        private Mock<IAircraftService> _aircraftServiceMock;
        private Mock<IPassengerService> _passengerServiceMock;

        [SetUp]
        public void SetUp()
        {
            _cashFlowCalculationServiceMock = new Mock<ICashFlowCalculationService>();
            _aircraftServiceMock = new Mock<IAircraftService>();
            _passengerServiceMock = new Mock<IPassengerService>();

            _flightValidationService = new FlightValidationService(_cashFlowCalculationServiceMock.Object, _aircraftServiceMock.Object, _passengerServiceMock.Object);
        }

        [TestCase(1, 2, 1, ExpectedResult = false)]
        [TestCase(5, 2, 0, ExpectedResult = true)]
        [TestCase(1200, 800, 40, ExpectedResult = true)]
        [TestCase(900, 600, 0, ExpectedResult = true)]
        public bool IsAdjustedRevenueWithinCostOfFlight_EnsureFlightProfitability(decimal totalRevenue, decimal totalCostOfFlightToAirline, decimal discountedAmountForPassengersOnFlight)
        {
            _cashFlowCalculationServiceMock.Setup(ccs => ccs.CalculateTotalRevenueFromPayingCustomers()).Returns(totalRevenue);
            _cashFlowCalculationServiceMock.Setup(ccs => ccs.CalculateTotalCostOfFlightToAirline()).Returns(totalCostOfFlightToAirline);
            _cashFlowCalculationServiceMock.Setup(ccs => ccs.CalculateDiscountedAmountForPassengersOnFlight()).Returns(discountedAmountForPassengersOnFlight);

            var isAdjustedRevenueWithinCost = _flightValidationService.IsAdjustedRevenueWithinCostOfFlight();

            return isAdjustedRevenueWithinCost;
        }

        [TestCase(1, 2, ExpectedResult = false)]
        [TestCase(5, 2, ExpectedResult = true)]
        [TestCase(5, 5, ExpectedResult = true)]
        public bool IsPassengerCountOnAircraftAboveMaxSeats_EnsurePassangersFitOnFlight(int seatCount, int numberOfPassengers)
        {
            _aircraftServiceMock.Setup(asrv => asrv.GetNumberOfSeatsOnPlane()).Returns(seatCount);
            _passengerServiceMock.Setup(ps => ps.GetNumberOfPassengers()).Returns(numberOfPassengers);

            var canPassengersFit = _flightValidationService.IsPassengerCountOnAircraftAboveMaxSeats();

            return canPassengersFit;
        }
    }
}
