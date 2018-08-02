# Contests

This repository is a collection of ASP.NET + jQuery pages used for contests. Each contest is explained below:

### Contest 1 (Contest.aspx)

This page listed a collection of radio buttons that were color images. Question was which color was most popular from the previous year. The choices were collected and output after the player entered their decision.

### Contest 2 & Contest 3

Simple question and answer form.

### Contest 4

Utilized the ImageColorPicker plugin to produce a spectrum of colors and asked the player to pick the color they found most soothing. Stored the hex as the answer and posted to the server.

### Contest 5

Players were asked to find the parts of the image that were colored incorrectly. An HTML5 canvas was overlayed on the image such that when they clicked the image a circle would appear where they clicked. On click the coordiantes were stored and pulled on form post. Server side the coordinates were checked against a range of acceptabled coordinates. An HTML file was created after the contest to view all the results.