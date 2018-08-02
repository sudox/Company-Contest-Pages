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

### Contest 6

Players were presented with a gray-scale image of the statue of liberty. The statue portion was semi-transparent so it was placed on an HTML5 canvas with a color picker that would adjust the background color of the canvas to show through the statue. After submission the HEX for the color picked would be posted back to the server and a collection of all the colors picked by others would be presented which would show what others had picked.

### Contest 7

This contest asked players to identify their hometown by selecting their Country and State/Region, typing in their hometown, and a color that they felt represented their hometown. Mostly a simple form outside of using a library containing automated drop downs for country + state/region combinations.

### Contest 8

Players were asked to come up with a caption for an image. On submit the server-side code would create an image that fit the caption inside a speech bubble then would output an HTML page and redirect them to the page to display all the captions in an image slider.