## Synopsis

At the top of the file there should be a short introduction and/ or overview that explains **what** the project is. This description should match descriptions added for package managers (Gemspec, package.json, etc.)
The project is created in visual studio 2017 version using .Net Framework version 4.6.2. It contains following files on the root:

1) Hotel_Search (ASP.NET WEB API)
2) Hotel.Search.Application (C# Class Library)
3) Hotel_Search_Test (C# Class Library containing Unit Tests for the actions implemented in Hotel_Search project)
4) packages (package assemblies being usedin all projects)
5) .travis.yml (file to trigger travis CI)
6) .coveralls.yml (file to trigger COVERALLS)
7) Hotel_Search.sln (visual studio solution file)
8) README.MD

## Installation

1) Open the .sln file in Visual Studio
2) Run Hotel_Search website
3) The website will open on port 58550

## API URLs

1) Search by Name

- Sort By Name:
- http://localhost:58550/api/hotels/name/media one hotel/sort/name

- Sort By Price:
- http://localhost:58550/api/hotels/name/media one hotel/sort/price

2) Search by Destination

- Sort By Name:
- http://localhost:58550/api/hotels/destination/dubai/sort/name

- Sort By Price:
- http://localhost:58550/api/hotels/destination/dubai/sort/price

3) Search by Price Range:

 - Sort By Name:
 - http://localhost:58550/api/hotels/price-range/20:100/sort/name
 
 - Sort By Price:
 - http://localhost:58550/api/hotels/price-range/20:100/sort/price
 
 4) Search by Date Range:
 
 - Sort By Name:
 - http://localhost:58550/api/hotels/date-range/20-11-2020:25-11-2020/sort/name
 
 - Sort By Price:
 - http://localhost:58550/api/hotels/date-range/20-11-2020:25-11-2020/sort/price

 
## Travis CI build badges

[![Build Status](https://travis-ci.org/ushay20/tajawal_assignment.svg?branch=master)](https://travis-ci.org/ushay20/tajawal_assignment)



## Contributors

Let people know how they can dive into the project, include important links to things like issue trackers, irc, twitter accounts if applicable.

## License

A short snippet describing the license (MIT, Apache, etc.)
