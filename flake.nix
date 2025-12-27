{
  description = "FindTheDesktop";

  inputs.nixpkgs.url = "github:NixOS/nixpkgs/nixos-25.11";

  outputs = { self, nixpkgs }: 
    let
      system = "x86_64-linux";
      pkgs = import nixpkgs { inherit system; };
    in
    {
      defaultPackage.${system} = pkgs.buildDotnetModule {
        pname = "FindTheDesktop";
        version = "0.1";
        description = "A tool to locate desktop files by name";

        src = ./.;

        projectFile = "FindTheDesktop.sln";
        dotnet-sdk = pkgs.dotnetCorePackages.sdk_10_0;
        dotnet-runtime = pkgs.dotnetCorePackages.runtime_10_0;
      };
    };
}
