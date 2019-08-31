# UnityMLDatacenterSimulator
 Game where you cool a server and try to beat the AI
 
 Unity2018.3.0f2
 
 UnityML API 0.9
 
[![Screenshot](https://github.com/fuzzballb/UnityMLDatacenterSimulator/blob/master/Screenshot.PNG)](https://www.youtube.com/watch?v=BhtJ-7Sc3kY)

# UnityML useful links

## Setting up the Python environment
https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Installation.md

Alternatively you can use miniconda, see clankill3r's comment

https://github.com/Unity-Technologies/ml-agents/issues/1979

> Atm we do it using the following steps, (we moved from pip to miniconda where possible).
> 
> install miniconda https://docs.conda.io/en/latest/miniconda.html
> 
> conda install python=3.6
> 
> conda create -n py36 python=3.6
> 
> source activate py36 (Do this everytime you open the terminal)
> 
> pip install "tensorflow==1.7.0"
> 
> conda install -c anaconda jupyter
> 
> pip install mlagents
> 
> navigate to the directory where you want the unity project installed:
>
> 
> 
> git clone https://github.com/Unity-Technologies/ml-agents
> 
> cd ml-agents
> 
> cd ml-agents-envs
> 
> pip install -e ./
> 
> cd ..
> 
> cd ml-agents
> 
> pip install -e ./


## Train your UnityML environment
https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Basic-Guide.md

https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Learning-Environment-Create-New.md

The type or namespace name 'TensorFlow' could not be found

https://github.com/Unity-Technologies/ml-agents/issues/1511
