# Jay's C# Libraries
### A collection of C# libraries (both source and DLL), with associated tools.

## C# Libraries
The C# libraries are split over the `src/` and `bin/` directory trees:  
 - `src/` contains the source (`*.cs`) files. (The `src/` tree represents the namespace tree as well: `Jay.IO.Logging` is stored in `src/Jay/IO/Logging`)  
 - `bin/` contains the precompiled (`*.dll`) files. (Each binary is stored in a file named after the namespace itself: `Jay.IO.Logging` is stored in `bin/Jay.IO.Logging.dll`)  
Documentation is found in the `docs/` tree, however, you may have to move to the docs branch since it's not always synced up (the links in this file redirect to that branch).  

Current libraries (namespaces) available, with a short description:  
 - `Jay`: the base namespace for all libraries (and tools).  
   - `Jay.Config`: a namespace containing configuration tools, see [Jay.Config](../../blob/docs/docs/Jay/Config.md).  
   - `Jay.IO`: a namespace containing input/output stuff, both via screen (stdout, stdin, ...) and via files.  
     - `Jay.IO.Logging`: a namespace containing loggers and their base interfaces, see [Jay.IO.Logging](../../blob/docs/docs/Jay/IO/Logging.md).  

## Associated tools
The tool scripts and executables are split over the `src/tools/` and `tools/` directory trees:  
 - `src/tools/` contains the source (`*.cs`) files. (Each tool has its own directory: `csprojgen` is stored in `src/tools/csprojgen`)  
 - `tools/` contains the executable (`*.dll`, mono-based) files. (Each tool has its own directory in which the binary and possible resources are stored)  
Documentation is found in the `docs/` tree, however, you may have to move to the docs branch since it's not always synced up (the links in this file redirect to that branch).  

Current tools available, with a short description:
 - `gencsproj`: A command-line tool to quickly generate simple *.csproj files; see [gencsproj](../../blob/docs/docs/tools/csprojgen.md)
