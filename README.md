# The problem

A small airline wants a simple program that produces flight summary reports based on flight, route and passenger data.

There are three types of passenger the airline will cater for:

General – normal fare-paying passengers.
Loyalty Members – repeat customers who get benefits for choosing to fly with the airline.
Airline Employees – employees of the airline who fly with the airline for free.
For each flight the airline charges a base ticket price for a specific route. Loyalty members can choose to pay with their loyalty points instead. Loyalty points are worth £1 each. Airline employees always fly free. All passengers are allocated 1 bag and loyalty members are allowed 1 extra bag. For simplicity, we assume that every passenger will bring at least 1 bag.

# task

Write a console application that accepts two filenames, the first is an input file, containing route, plane and passenger data, the second is an output file to which the flight summary report must be written.

### Input

The format of the input file is a set of lines that represent either plane, route or passenger information. Your program should read each line in the input file and process each instruction.

#### For example:

add route London Dublin 100 150<br>
add aircraft Gulfstream-G550 8<br>
add passenger airline Trevor<br>
add passenger general Mark<br>
add passenger loyalty Joan 100 FALSE TRUE<br>

add route {origin} {desination} {cost-to-airline-per-passenger} {ticket-price}<br>
add aircraft {aircraft-model} {total-seats}<br>
add passenger general {passenger-name}<br>
add passenger airline {passenger-name}<br>
add passenger loyalty {passenger-name} {current-loyalty-points} {using-loyalty-points} {has-extra-bag}<br>


Loyalty passengers are able to use loyalty points for discounts against tickets.

If they are using their loyalty points then £1 is taken off the price of the ticket for every loyalty point used. These customers then pay the remainder of the normal ticket price.

Loyalty passengers have the option to bring an extra bag.

An input file must add only one route and one aircraft.

### Output

Your program should read the input file, compute a flight summary report and write it to the output JSON file.

```javascript
{
  "passengers": {number}, // total number of passengers on the flight
  "generalPassengers": {number}, // number of general passengers on the flight
  "airlinePassengers": {number}, // number of airline passengers on the flight
  "loyaltyPassengers": {number}, // number of loyalty passengers on the flight
  "bags": {number}, // the total number of bags on the plane
  "loyaltyPointsUsed": {number}, // the total number of loyalty points redeemed by all passengers
  "costOfFlight": {number}, // the total cost to the airline of running the flight
  "revenueBeforeDiscounts": {number}, // the total ticket revenue, ignoring loyalty and airline passenger adjustments
  "revenueAfterDiscounts": {number}, // the total ticket revenue, after adjusting for loyalty members points and airline passengers
  "canFlightProceed": {boolean} // can the flight proceed, according to the rules defined below
}
```
### Flight rules

A flight proceeds only if all of the following rules are met:

The total adjusted revenue for the flight exceeds the total cost of the flight.
The number of passengers does not exceed the number of seats on the plane.
Example input and output

### Input file

add route London Dublin 100 150<br>
add aircraft Gulfstream-G550 8<br>
add passenger general Mark<br>
add passenger general Tom<br>
add passenger general James<br>
add passenger airline Trevor<br>
add passenger loyalty Alan 50 FALSE FALSE<br>
add passenger loyalty Susie 40 TRUE FALSE<br>
add passenger loyalty Joan 100 FALSE TRUE<br>
add passenger general Jack<br>

### Output file
```javascript
{
  "passengers": 8,
  "generalPassengers": 4,
  "airlinePassengers": 1,
  "loyaltyPassengers": 3,
  "bags": 9,
  "loyaltyPointsUsed": 40,
  "costOfFlight": 800,
  "revenueBeforeDiscounts": 1200,
  "revenueAfterDiscounts": 1010,
  "canFlightProceed": true
}
```

This flight can proceed.

### Input file

add route London Dublin 100 150<br>
add aircraft Gulfstream-G550 12<br>
add passenger general Mark<br>
add passenger general Tom<br>
add passenger general James<br>
add passenger airline Jack<br>
add passenger airline Jane<br>
add passenger airline Steve<br>

### Output file
```javascript
{
  "passengers": 6,
  "generalPassengers": 3,
  "airlinePassengers": 3,
  "loyaltyPassengers": 0,
  "bags": 6,
  "loyaltyPointsUsed": 0,
  "costOfFlight": 600,
  "revenueBeforeDiscounts": 900,
  "revenueAfterDiscounts": 450,
  "canFlightProceed": false
}
```

This flight cannot proceed, as revenue after discounts is less than the cost of the flight.