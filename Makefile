publish-first-mod:
	dotnet publish ./src/ta.FirstMod/ --output dist/src-ta.FirstMod
	rm -rf ./dist/ta.FirstMod/
	mkdir -p ./dist/ta.FirstMod/
	mkdir -p ./dist/ta.FirstMod/plugin/
	cp ./dist/src-ta.FirstMod/ta.FirstMod.dll ./dist/ta.FirstMod/plugin/
	cp ./dist/src-ta.FirstMod/ta.FirstMod.pdb ./dist/ta.FirstMod/plugin/
	cp ./src/ta.FirstMod/modinfo.json ./dist/ta.FirstMod/
	cp ./src/ta.FirstMod/workshopdata.json ./dist/ta.FirstMod/
	cp ./src/ta.FirstMod/thumbnail.png ./dist/ta.FirstMod/
	rm -rf ./dist/src-ta.FirstMod/
