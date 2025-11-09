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

publish-uikit:
	dotnet publish ./src/ta.UIKit/ --output dist/src-ta.UIKit
	rm -rf ./dist/ta.UIKit/
	mkdir -p ./dist/ta.UIKit/
	mkdir -p ./dist/ta.UIKit/plugins/
	cp -r ./dist/src-ta.UIKit/* ./dist/ta.UIKit/plugins/
	cp ./src/ta.UIKit/modinfo.json ./dist/ta.UIKit/
	cp ./src/ta.UIKit/workshopdata.json ./dist/ta.UIKit/
	cp ./src/ta.UIKit/thumbnail.png ./dist/ta.UIKit/
	rm -rf ./dist/src-ta.UIKit/