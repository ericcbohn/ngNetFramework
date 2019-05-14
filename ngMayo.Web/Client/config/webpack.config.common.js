// https://medium.freecodecamp.org/how-to-configure-webpack-4-with-angular-7-a-complete-guide-9a23c879f471

'use strict';

const CleanWebpackPlugin = require("clean-webpack-plugin");
const HtmlWebpackPlugin = require("html-webpack-plugin");

const path = require('path'); // TODO: use helpers.js
const helpers = require('./helpers');
const isDev = process.env.NODE_ENV !== 'production';

module.exports = {
    entry: {
        vendor: './src/vendor.ts',
        polyfills: './src/polyfills.ts',
        main: isDev ? './src/main.ts' : './src/main.aot.ts'
    },
    resolve: {
        extensions: ['.ts', '.js', '.scss']
    },
    module: {
        rules: [
            { test: /\.html$/, loader: 'html-loader' },
            {
                test: /\.(scss|sass)$/,
                use: [
                    { loader: 'style-loader', options: { sourceMap: isDev } },
                    { loader: 'css-loader', options: { sourceMap: isDev } },
                    { loader: 'sass-loader', options: { sourceMap: isDev } }
                ],
                include: helpers.root('src', 'assets')
            },
            {
                test: /\.(scss|sass)$/,
                use: [
                    'to-string-loader',
                    { loader: 'css-loader', options: { sourceMap: isDev } },
                    { loader: 'sass-loader', options: { sourceMap: isDev } }
                ],
                include: helpers.root('src', 'app')
            }
        ]
    },
    plugins: [
        new HtmlWebpackPlugin({
            inject: "body",
            filename: helpers.root("dist/_Layout.cshtml"),
            template: helpers.viewsRoot("Views/Shared/_Layout_Template.cshtml")
        }),
        new CleanWebpackPlugin({ verbose: true })
    ]
}