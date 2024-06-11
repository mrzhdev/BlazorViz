# BlazorViz
Visualization  for C#, Blazor interop wrapper for Viz.js

Live demo: <https://mrzhdev.github.io/BlazorViz/>

# Intro

I usually use C# for prototyping and development of algorithms, and for one of my projects, I needed some tree data structures visualization. I came up with this idea, and I’m sharing with you this quick and dirty code.

For this solution, I have used Visual Studio 2022 Preview and .NET 6.0 



**Blazor web client project (BlazorVizView):**

- [Viz.js](https://github.com/mdaines/viz.js), Emscripten version of [Graphviz](https://graphviz.org/)
- [svg-pan-zoom.js](https://github.com/ariutta/svg-pan-zoom), pan/zoom for HTML SVG
- vizInterop.js custom Javascript code to put everything together
- reference to an external dummy project (DummyClassLibrary)

 

**C# Class library project (DummyClassLibrary):**

- Roslyn CSharpSyntaxWalker to generate [Graphviz](https://graphviz.org/) DOT language file



### Screenshot
![image](https://user-images.githubusercontent.com/47992551/179770048-cfed6985-e791-463b-b8be-982d0aead9c0.png)
