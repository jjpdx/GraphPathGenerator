# GraphPathGenerator
Blazor-based student project for generating graphs and calculating the shortest path between two given vertices.

## Table of contents
  * [Features](#features)
  * [Initial Plans](#initial-plans)
  * [Outcomes](#outcomes)
  * [Possible Improvements](#improvements)
  * [Known Bugs](#bugs)
  
## Features
 * Mouse and keyboard controls to use with a canvas to create and rename vertices as well as connect them with edges.
 * Entering a Start and End vertex allows user to use Find Paths to write the shortest possible path in the console and highlights those edges.
 * Console with basic error reporting.
  
## Initial Plans
Originally, the goal was to make a way of determining the path for an user-defined graph fitting a few different criteria such as: 
 * Shortest path
 * Longest path (with no looping)
 * Random inputs (instead outputting average distance)

## Outcomes
After around 12 hours of work, I succeeded in my minimum viable product design. 
It has a fairly intuitive UI for creating a graph and the way that the vertices and edges are handled as components works well.
I'm happy with the scalability of the process. It could easily be expanded to fulfill other goals for types of paths to generate.
A few inefficiencies:
 * There is likely a better way to implement parameter inheritance with components, essentially I have two working lists of vertices (and edges), one in the DOM and one used for data manipulation by the main page.
 * I used a couple while loops in my PathfinderService code, it seems unavoidable but there is likely a better way. Theoretically for each loop there is no infinite possible.
 * My PathfinderService code reused the same data passed through different functions, I'm unsure whether it would be better to have those sets of data as variables within the service instance itself.
 
## Potential Improvements
 * Ability to toggle between alternate and equal paths (currently only prints out the first path that has the minimum length).
 * Saving graph between refreshes.
 * New types of path generation as listed in initial plans.
 * Way to import existing graph.
 * Zooming for use on very large imported graphs.
 * Better controls for more quickly creating graphs.
 
## Bugs
Known bugs:
 * Automatic numbering always starts at 1 and is unaware of existing vertices
 * Double clicking on a vertex will create a new vertex and its coordinates will be based on your mouse's position on the clicked vertex instead of the div (so it always appears up in the corner).
 * Some extreme weirdness with hitting delete multiple times while trying to delete a single vertex.
