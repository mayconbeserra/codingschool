# Coding School Kata

The LOC kata seems really interesting. In the first moment, it seems pretty simple but some edge cases made it a little bit more complex.

I've thought in 2 implementations:

- Without Regular expression (Not solve all the cases, but nicer code);
- With Regular expression in order to get most of the cases.

I've choosen the second one to accomplish the Kata.

## Requirements

- .NET Core 3.1 sdk
- Docker (Optional)

## Tests

As this is a Kata, I've implemented it as a test project in order to achieve the goal.

Some further development should be the extraction of the tests to another project to provide a cleaner solution.

Besides that, to avoid some issues with environments (mac and windows), the tests can be run inside docker.

## How to Run

`docker build --tag codingschool .`

`docker run codingschool`
