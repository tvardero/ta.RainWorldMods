publish-first-mod:
	dotnet publish ./src/ta.FirstMod/ --output dist/src-ta.FirstMod
	rm -rf ./dist/ta.FirstMod/
	mkdir -p ./dist/ta.FirstMod/
	mkdir -p ./dist/ta.FirstMod/plugins/
	cp -r ./dist/src-ta.FirstMod/* ./dist/ta.FirstMod/plugins/
	cp ./src/ta.FirstMod/modinfo.json ./dist/ta.FirstMod/
	cp ./src/ta.FirstMod/workshopdata.json ./dist/ta.FirstMod/
	cp ./src/ta.FirstMod/thumbnail.png ./dist/ta.FirstMod/
	rm -rf ./dist/src-ta.FirstMod/

publish-ui-kit:
	dotnet publish ./src/ta.UiKit/ --output dist/src-ta.UiKit
	rm -rf ./dist/ta.UiKit/
	mkdir -p ./dist/ta.UiKit/
	mkdir -p ./dist/ta.UiKit/plugins/
	cp -r ./dist/src-ta.UiKit/* ./dist/ta.UiKit/plugins/
	cp ./src/ta.UiKit/modinfo.json ./dist/ta.UiKit/
	cp ./src/ta.UiKit/workshopdata.json ./dist/ta.UiKit/
	cp ./src/ta.UiKit/thumbnail.png ./dist/ta.UiKit/
	rm -rf ./dist/src-ta.UiKit/