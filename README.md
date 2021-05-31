# GraphPathGenerator
Blazor-based student project for generating graphs and calculating the shortest path between two given vertices.

For an example of using the tool see the video below:
https://user-images.githubusercontent.com/7828219/120140978-765a1a80-c190-11eb-92d1-306986a3b9c3.mp4

## Table of contents
  * [Instructions](#instructions)
  * [Features](#features)
  * [Initial Plans](#initial-plans)
  * [Outcomes](#outcomes)
  * [Possible Improvements](#improvements)
  * [Known Bugs](#bugs)
  
## Instructions
Steps to build and run locally:
 * Download latest release and unzip source file
 * From command prompt, cd to project folder and type dotnet run
 * It will give you a localhost address (i.e. http://localhost:5000) to put into your browser
  
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
I built the UI as Blazor components using HTML5, CSS, and dynamically created JS from C# using JSInterop. The functionality of determining the shortest path was accomplished in the PathfinderService which uses a variation of a breadth-first search to create a working dictionary of each vertex associated with it's direct ancestor (in terms of distance to the starting vertex) and its own distance. Unfortunately, I didn't have time to create a way for the tool to handle other types of pathfinding. This project taught me a lot about how to deal with using graphs in computation.
 
## Potential Improvements
 * Ability to toggle between alternate and equal paths (currently only prints out the first path that has the minimum length).
 * Saving graph between refreshes.
 * New types of path generation as listed in initial plans.
 * Way to import existing graph.
 * Zooming for use on very large imported graphs.
 * Better controls for more quickly creating graphs.
 * Reexamine parameter inheritance for Blazor components, avoid having two working lists of each component.
 * Reexamine PathfinderService's handling of reused data.
 
## Bugs
Known bugs:
 * Automatic numbering always starts at 1 and is unaware of existing vertices
 * Double clicking on a vertex will create a new vertex and its coordinates will be based on your mouse's position on the clicked vertex instead of the div (so it always appears up in the corner).
 * Some extreme weirdness with hitting delete multiple times while trying to delete a single vertex.
