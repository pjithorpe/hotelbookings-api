## hotelbookings-api

# Hotels
* GET api/hotels - Lists all hotels
* GET api/hotels?name=\[NAME\] - Gets all hotels with name of \[NAME\]
* POST api/hotels - Add new hotel to database from request body

&nbsp;

# Rooms
* GET api/rooms - Lists all rooms
* GET api/rooms?start_date=\[START DATE\]&end_date=\[END DATE\]&party_size=\[PARTY SIZE\] - Gets all rooms available between \[START DATE\] and \[END DATE\] for a party size of \[PARTY SIZE\]
* POST api/rooms - Add new room to database from request body

&nbsp;

# Bookings
* GET api/bookings - Lists all bookings
* GET api/bookings?id=\[BOOKING ID\] - Gets booking with id of \[BOOKING ID\]
* POST api/bookings - Add new booking to database from request body

&nbsp;

# API Testing
* GET api/reset - Clears the database (call before using api/seed)
* GET api/seed - Seeds the database with some example data