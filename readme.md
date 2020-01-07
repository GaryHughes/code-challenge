# Assumptions #

* Each input file is processed separately, the existing code could be simply adapted to consolidate them if required.
* A given race can only contain one instance of a horse.
* A race can contain multiple horses each with the same price.

# Notes #

* The XML parser is fragile.
* The program has been developered and tested on macOS with VSCode using .Net Core 3.1, it should run elsewhere with a comparable environment.

# Running #

```script
> dotnet run FeedData

Evergreen Turf Plate
--------------------
4.2	    Advancing
12	    Coronel

Evergreen Terrace Plate
-----------------------
42	    Coronel
44.2	Advancing

```