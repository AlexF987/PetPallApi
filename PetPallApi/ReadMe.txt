Type of Request		URI		Parameters		Result
---------------		---		----------		------
GET			api/pets				List of all pets
GET			api/pets	ownerid			List of all pets belonging to owner with id=ownerid
GET			api/petwalkers	id,ownerid		true if owner approves of walker, otherwise false
GET			api/pets	id			Get pet with this id
POST			api/pets				Create a new pet, JSON body required
PUT			api/pets	id			Update pet, JSON body required
GET			api/pets	age			List of pets younger than the given age.