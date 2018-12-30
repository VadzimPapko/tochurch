import React, { Component } from 'react';

export class Home extends Component {
    displayName = Home.name

    constructor(props) {
        super(props);

        this.state = {
            error: null,
            items: [],
            mymap: null
        };
    }

    componentWillMount() {
        console.log('---', 'mounting');
        fetch('https://localhost:44379/api/osmmap')
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        items: result
                    });
                    console.log('---', result);
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    });
                }
            );
    }

    componentDidMount() {
        console.log('---', 'didmounting');

        var mymap = window.L.map('mapid').setView([53.893, 27.567], 12);

        window.L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
            attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
            maxZoom: 18,
            id: 'mapbox.streets',
            accessToken: 'pk.eyJ1IjoidnBhcGtvIiwiYSI6ImNqcTZoZzZlYTI4NzY0M29iYWp1NDE4NHEifQ.NB_BwbfTtnnLIIOkrIsRgQ'
        }).addTo(mymap);

        this.setState({ mymap: mymap });
    }

    render() {
        const { error, items, mymap } = this.state;

        if (items.length > 0) {
            items.forEach(function (item) {
                var markerOsm = window.L.marker([item.lat, item.lon]).addTo(mymap);
                markerOsm.bindPopup("<b>Hello, marker</b>");
            });
        }

        return (
            <div>
                <h1>Hello, world!</h1>
                <p>Welcome to your new single-page application, built with:</p>
                <ul>
                    <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
                    <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
                    <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
                </ul>
                <p>To help you get started, we've also set up:</p>
                <ul>
                    <li><strong>Client-side navigation</strong>. For example, click <em>Counter</em> then <em>Back</em> to return here.</li>
                    <li><strong>Development server integration</strong>. In development mode, the development server from <code>create-react-app</code> runs in the background automatically, so your client-side resources are dynamically built on demand and the page refreshes when you modify any file.</li>
                    <li><strong>Efficient production builds</strong>. In production mode, development-time features are disabled, and your <code>dotnet publish</code> configuration produces minified, efficiently bundled JavaScript files.</li>
                </ul>
                <p>The <code>ClientApp</code> subdirectory is a standard React application based on the <code>create-react-app</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands such as <code>npm test</code> or <code>npm install</code>.</p>

                <h1>OSM</h1>
                <div id="mapid" />
            </div>
        );
    }
}
