[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]


<!-- PROJECT LOGO -->
<br />
<div align="center">
  <h3 align="center">Collatz conjecture calculator</h3>

  <p align="center">
    A calculator was developed to calculate the Collatz sequence for large numbers.
    <br />
       <br />
    <a href="https://github.com/KreminT/collatz-conjecture/issues">Report Bug</a>
    ·
    <a href="https://github.com/KreminT/collatz-conjecture/issues">Request Feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Collatz conjecture</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Collatz conjecture

The Collatz conjecture is one of the most famous unsolved problems in mathematics. The conjecture asks whether repeating two simple arithmetic operations will eventually transform every positive integer into 1. It concerns sequences of integers in which each term is obtained from the previous term as follows: if the previous term is even, the next term is one half of the previous term. If the previous term is odd, the next term is 3 times the previous term plus 1. The conjecture is that these sequences always reach 1, no matter which positive integer is chosen to start the sequence.

### Built With

* [![React][React.js]][React-url]
* [![.net6][.net6]][.net6-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- GETTING STARTED -->
## Getting Started

This application has backand part on .Net and react-frontend. To use it need to build and run docker image in container.

### Installation

1. Install docker-desktop
2. Clone the repo
   ```sh
   git clone https://github.com/KreminT/collatz-conjecture.git
   ```
4. Build docker image
   ```docker build -t collatz-calculator:latest .```
5. Run image
   ```docker run -v {path on your pc like C://collatz}:/app/result -p 9919:80/tcp collatz-calculator:lates```
6. Open http://localhost:9919/ in your web browser

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage
To use calculator:
1. Enter number
2. Change multiplier if needed; default is 3; multiplier*x+1
3. Change operation if needed;default  adding; multiplier*x {operation} 1
4. Set max iteration; available if multiplier was changed; max numbers in sequence;
5. Set result range, program can select a specific range of results

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- CONTRIBUTING -->
## Contributing

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Kremin T - kremin.t@gmail.com

Project Link: [https://github.com/KreminT/collatz-conjecture/](https://github.com/KreminT/collatz-conjecture/)

<p align="right">(<a href="#readme-top">back to top</a>)</p>





<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[forks-shield]: https://img.shields.io/github/forks/KreminT/collatz-conjecture.svg?style=for-the-badge
[forks-url]: https://github.com/KreminT/collatz-conjecture/network/members
[stars-shield]: https://img.shields.io/github/stars/KreminT/collatz-conjecture.svg?style=for-the-badge
[stars-url]: https://github.com/KreminT/collatz-conjecture/stargazers
[issues-shield]: https://img.shields.io/github/issues/KreminT/collatz-conjecture.svg?style=for-the-badge
[issues-url]: https://github.com/KreminT/collatz-conjecture/issues
[license-shield]: https://img.shields.io/github/license/KreminT/collatz-conjecture.svg?style=for-the-badge
[license-url]: https://github.com/KreminT/collatz-conjecture.svg/blob/master/LICENSE.txt
[React.js]: https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB
[React-url]: https://reactjs.org/
[.net6]: https://img.shields.io/badge/net-6?style=for-the-badge&logo=react&logoColor=61DAFB
[.net6-url]: https://dotnet.microsoft.com/en-us/download/dotnet/6.0
[product-screenshot]: images/screenshot.png
