const path = require("path");
const glob = require("glob");
const BomPlugin = require('webpack-utf8-bom');

let rootPath = path.resolve(__dirname);
let srcPath = rootPath + "\\src";
//let distPath = "E:\\Development\\VisualStudio\\Blog\\src\\presentation\\Blog.Web\\wwwroot\\script\\frameworkJs";
let distPath = "C:\\Users\\caglar.ozcan\\source\\repos\\Blog\\src\\presentation\\Blog.Web\\wwwroot\\script\\frameworkJs";

function getFiles() {
	const entries = {};

	(glob.sync(path.relative("./", srcPath) + "/**/**/!(_)*.js") || [])
		.filter((f) => {
			return /\/bundle\/.*?\.js/.test(f) === false;
		})
		.forEach((file) => {
			entries[file.replace(/.*js\/(.*?)\.js$/gi, "js/$1").replace("src/", '')] = "./" + file;
		});

	(glob.sync(path.relative("./", srcPath) + "/!(_)*.js") || [])
		.filter((f) => {
			return /\/bundle\/.*?\.js/.test(f) === false;
		})
		.forEach((file) => {
			entries[file.replace(/.*js\/(.*?)\.js$/gi, "js/$1").replace("src/", '')] = "./" + file;
		});

	console.log(entries);

	return entries;
}

function mainConfig() {
	return {
		entry: getFiles(),
		output: {
			path: distPath,
			filename: "[name]",
		},
		resolve: {
			extensions: ['.js'],
			fallback: {
				util: false,
			},
		},
		devServer: {
			static: {
				directory: distPath,
			},
			compress: true,
			port: 9000,
		},
		module: {
			rules: [],
		},
		plugins: [
			new BomPlugin(false)
		]
	};
}

module.exports = () => {
	return [mainConfig()];
};
