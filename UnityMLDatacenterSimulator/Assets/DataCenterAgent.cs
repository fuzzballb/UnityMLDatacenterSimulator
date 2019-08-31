using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAgents;

public class DataCenterAgent : Agent
{
    public GameObject CoolerValue;
    public GameObject BatteryValue;

    public GameObject BatteryMeanValue;
    public GameObject DataStreamValue;
    public GameObject ServerHeatValue;
    public GameObject ServerStatusValue;
    public GameObject TimeAliveValue;
    public GameObject VectorActionValue;

    public GameObject EpisodesValue;
    public GameObject ServersKilledValue;

    enum ServerStatusEnum { Idle = 0, Operational = 1, HeavyLoad = 2, Critical = 3, Broken = 4, Frozen = 5}

    float Cooler;
    float Battery;
    float BatteryAccumulated;

    float DataStream;
    float ServerHeat;
    float TimeAlive;
    int serverStatus;
    int changeDatastreamTime;
    bool alive;

    int episodes;
    int serversKilled;


    // Start is called before the first frame update
    void Start()
    {
        // move GetComponents here
        BatteryAccumulated = 0;
        episodes = 0;
        serversKilled = 0;

        Application.targetFrameRate = 1;
    }

    public override void AgentReset()
    {
        // value to be controlled
        Cooler = 0;

        // values to be observed
        Battery = 0;
        DataStream = Random.value;
        //ServerHeat = 100;
        ServerHeat = 50;
        changeDatastreamTime = 0;

        // reward
        TimeAlive = 0;



        serverStatus = 0;
        alive = true;

        episodes += 1;

    }


    public override void CollectObservations()
    {
        // Target and Agent positions
        //AddVectorObs(Battery);
        //AddVectorObs(DataStream);

        AddVectorObs(Cooler);
        AddVectorObs(ServerHeat);

        //AddVectorObs(Battery);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {






        Cooler += vectorAction[0] / 50;
        
        


        if (Cooler < 0)
        {
            //AddReward(-1.0f);
            Cooler = 0;
        }

        Battery += Cooler;

        ////
        ////  cooler meet server heat as fast as possible
        ////

        //// make sure it reaches it's goal as fast as possible
        //AddReward(-0.002f);

        //// its a cooler, not a heater, vector action can be minus though
        //// the reward is less then the step pennalty 
        //if (Cooler > 0)
        //{
        //    AddReward(0.001f);
        //}

        //// if you reached serverheat 
        //if (Cooler >= ServerHeat && Cooler <= ServerHeat + 10)
        //{
        //    AddReward(100);
        //    Debug.Log("Test Time lived : " + TimeAlive);
        //    Done();//Reset
        //}


        //
        //  keep Serverheat within bounds as long as possible 
        //

        // heat upo he server with the datastream
        ServerHeat += DataStream;


        // break when freezing of overheating
        if (ServerHeat < -10 )
        {
            serversKilled++;

            // give a penalty for using battery
            AddReward(Battery * -0.01f);


            //// give a penalty for freezing the server
            AddReward(-10.0f);

            Debug.Log("Test Time lived : " + TimeAlive + " DataStream : " + DataStream + " Power usage : " + Battery + " Frozen");
            Done();
        }
        if (ServerHeat > 150)
        {
            serversKilled++;

            // give a penalty for using battery
            AddReward(Battery * -0.01f);


            //// give a penalty for overheating the server
            AddReward(-10.0f);

            Debug.Log("Test Time lived : " + TimeAlive + " DataStream : " + DataStream + " Power usage : " + Battery + " Overheated");
            Done();
        }



        // make sure it lives as long as possible
        AddReward(0.02f);


        // cooler efficientcy 50%
        ServerHeat -= Cooler/2;




        if (TimeAlive > 1000)
        {
            // give a penalty for using battery
            AddReward(Battery * -0.01f);

            //// give a reward for keeping the server alive
            AddReward(10.0f);

            // if training
            Debug.Log("Test Time lived : " + TimeAlive + " DataStream : " + DataStream + " Power usage : " + Battery + " Operational");

            BatteryAccumulated += Battery;

            Done();

            // if playing
            //DataStream = Random.value / 10;
        }


        TimeAlive += 1;






















        //// Actions, size = 1
        //Cooler += vectorAction[0] / 100;

        //// Game code starts here
        //TimeAlive += 1;
        //changeDatastreamTime += 1;
        //if (changeDatastreamTime == 100)
        //{
        //    DataStream = 10; //Random.value / 2;
        //    changeDatastreamTime = 0;
        //}

        //// Calculate server heat warmup
        //ServerHeat = ServerHeat + DataStream/10;
        //// Calculate server heat cooldown
        //if (Battery >= Cooler)
        //{
        //    ServerHeat = ServerHeat - Cooler;
        //}


        //// Set Server status

        //if (ServerHeat < -100)
        //{
        //    serverStatus = (int)ServerStatusEnum.Frozen;
        //}
        //else if (ServerHeat == 0)
        //{
        //    serverStatus = (int)ServerStatusEnum.Idle;
        //}
        //else if (ServerHeat > 0 && ServerHeat < 800) { serverStatus = (int)ServerStatusEnum.Operational; }
        //else if (ServerHeat > 800 && ServerHeat < 900) { serverStatus = (int)ServerStatusEnum.HeavyLoad; }
        //else if (ServerHeat > 900 && ServerHeat < 1000) { serverStatus = (int)ServerStatusEnum.Critical; }
        //else if (ServerHeat > 1000)
        //{
        //    serverStatus = (int)ServerStatusEnum.Broken;
        //}

        //// Update battery
        //Battery += -Cooler;


        //AddReward(0.05f);


        //if (TimeAlive == 100000f)
        //{
        //    Done();//Reset
        //}

        //// Broken or frozen
        //if (serverStatus == (int)ServerStatusEnum.Broken || serverStatus == (int)ServerStatusEnum.Frozen)
        //{
        //    if (serverStatus == (int)ServerStatusEnum.Broken)
        //    {
        //        Debug.Log("Time alive : " + TimeAlive + " - Broken");
        //    }
        //    if (serverStatus == (int)ServerStatusEnum.Frozen)
        //    {
        //        Debug.Log("Time alive : " + TimeAlive + " - Frozen");
        //    }
        //    //AddReward(-100f);
        //    Done();
        //}




        // Update UI
        CoolerValue.GetComponent<Text>().text = Cooler.ToString();
        BatteryValue.GetComponent<Text>().text = Battery.ToString();
        DataStreamValue.GetComponent<Text>().text = DataStream.ToString();
        ServerHeatValue.GetComponent<Text>().text = ServerHeat.ToString();
        TimeAliveValue.GetComponent<Text>().text = TimeAlive.ToString();
        VectorActionValue.GetComponent<Text>().text = vectorAction[0].ToString();

        BatteryMeanValue.GetComponent<Text>().text = (BatteryAccumulated / episodes).ToString();
        EpisodesValue.GetComponent<Text>().text = episodes.ToString();
        ServersKilledValue.GetComponent<Text>().text = serversKilled.ToString();




        if (serverStatus == (int)ServerStatusEnum.Idle)
        {
            ServerStatusValue.GetComponent<Text>().text = "Idle";
        }
        if (serverStatus == (int)ServerStatusEnum.Operational)
        {
            ServerStatusValue.GetComponent<Text>().text = "Operational";
        }
        if (serverStatus == (int)ServerStatusEnum.HeavyLoad)
        {
            ServerStatusValue.GetComponent<Text>().text = "HeavyLoad";
        }
        if (serverStatus == (int)ServerStatusEnum.Critical)
        {
            ServerStatusValue.GetComponent<Text>().text = "Critical";
        }
        if (serverStatus == (int)ServerStatusEnum.Broken)
        {
            ServerStatusValue.GetComponent<Text>().text = "Broken";
        }
        if (serverStatus == (int)ServerStatusEnum.Frozen)
        {
            ServerStatusValue.GetComponent<Text>().text = "Frozen";
        }

    }






    public void Change(float f)
    {
        Cooler = f;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            
        }

    }
}
