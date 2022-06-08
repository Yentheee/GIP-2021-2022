#include <ArduinoMqttClient.h>
#include <WiFiNINA.h> // for MKR1000 change to: #include <WiFi101.h>
#include "DHT.h"
#include "arduino_secrets.h"

char ssid[] = SECRET_SSID;        // your network SSID (name)
char pass[] = SECRET_PASS;    // your network password (use for WPA, or use as key for WEP)

#define DHTPIN1 2
#define DHTPIN2 8     
#define DHTTYPE DHT11   
double temperatuur;

#define SAMPLES 300   //Number of samples you want to take everytime you loop
#define ACS_Pin A0    //ACS712 data pin analong input


float High_peak,Low_peak;         //Variables to measure or calculate
float Amps_Peak_Peak, Amps_RMS = 0;



DHT dht1(DHTPIN1, DHTTYPE);
DHT dht2(DHTPIN2, DHTTYPE);

WiFiClient wifiClient;
MqttClient mqttClient(wifiClient);

const char broker[] = "test.mosquitto.org";
int        port     = 1883;
const char topic[]  = "arduino/simple";

int ventilator = 12;
int licht = 11; 
int stopcontact = 10;

double current;

String message;
int count = 0;

//float t = dht.readTemperature();
const long interval = 1000;
unsigned long previousMillis = 0;

void setup() {
  Serial.begin(9600);

  pinMode(stopcontact, OUTPUT);
  pinMode(ventilator, OUTPUT);
 
  pinMode(ACS_Pin,INPUT);        //Define pin mode
  
  dht1.begin();
  dht2.begin();
    
  while (!Serial) {
    ; // wait for serial port to connect. Needed for native USB port only
  }
  
// attempt to connect to Wifi network:
  Serial.print("Attempting to connect to WPA SSID: ");
  Serial.println(ssid);
  while (WiFi.begin(ssid, pass) != WL_CONNECTED) {
    // failed, retry
    Serial.print(".");
    delay(5000);
  }

  Serial.println("You're connected to the network");
  Serial.println();

   Serial.print("Attempting to connect to the MQTT broker: ");
  Serial.println(broker);

  if (!mqttClient.connect(broker, port)) {
    Serial.print("MQTT connection failed! Error code = ");
    Serial.println(mqttClient.connectError());

    while (1);
  }

Serial.println("You're connected to the MQTT broker!");
  Serial.println();

  Serial.print("Subscribing to topic: ");
  Serial.println(topic);
  Serial.println();

  // subscribe to a topic
  mqttClient.subscribe(topic);

}

void loop() {
//-----------receive data-------------
  Serial.print("Waiting for messages on topic: ");
  Serial.println(topic);
  Serial.println();
  
  int messageSize = mqttClient.parseMessage();
  if (messageSize) {
    // we received a message, print out the topic and contents
    Serial.print("Received a message with topic '");
    Serial.println(mqttClient.messageTopic());

    // use the Stream interface to print the contents
    while (mqttClient.available()) {
      message = ((String)mqttClient.readString());
    }
    Serial.println();
    
    Serial.println(message);
 if(message == "on")
    {
      Serial.println("led aan");
      digitalWrite(licht, HIGH);
    }
    else if(message == "off")
    {
      Serial.println("led uit");
      digitalWrite(licht, LOW);
    }
    else
    {
      Serial.println("fout");
    }
      
  }

//----------Current-----------
unsigned int x=0;
float AcsValue=0.0,Samples=0.0,AvgAcs=0.0,AcsValueF=0.0;

  for (int x = 0; x < 150; x++){ //Get 150 samples
  AcsValue = analogRead(A0);     //Read current sensor values   
  Samples = Samples + AcsValue;  //Add samples together
  delay (3); // let ADC settle before next sample 3ms
}
AvgAcs=Samples/150.0;//Taking Average of Samples

AcsValueF = (2.5 - (AvgAcs * (5.0 / 1024.0)) )/0.066;

if(AcsValueF <0)
{
  current = 0;
}
else
{
  current = AcsValueF;
}


//----------temperature-----------
   // put your main code here, to run repeatedly:
   int Status1;
   
  float t1 = dht1.readTemperature();
  if (isnan(t1)) {
    //Serial.println("Failed to read from DHT sensor 1!");
    Status1 = 0;
    delay(1000);
    return;
  }
  else
  {
    Status1 = 1;
  }

  int Status2;
  float t2 = dht2.readTemperature();
  if (isnan(t2)) {
    //Serial.println("Failed to read from DHT sensor 2!");
    Status2 = 0;
    delay(1000);
    return;
  }
  else
  {
    Status2 = 1;
  }

  
  if (Status1 == 0)
  {
    temperatuur = t2;
    Serial.println("sensor1 is kapot");
  }
  else if (Status2 == 0)
  {
    temperatuur = t1;
    Serial.println("sensor2 is kapot");
  }
  else 
  {
    temperatuur = (t1 + t2)/2;
  }
  
  if(temperatuur >= 26)
  {
    digitalWrite(ventilator, HIGH);
    digitalWrite(stopcontact, LOW); 
  }
  else if(temperatuur < 25)
  {
    digitalWrite(ventilator, LOW);
    //digitalWrite(Current, HIGH);
  }
  

//--------------send data---------------------
  // call poll() regularly to allow the library to send MQTT keep alives which
  // avoids being disconnected by the broker
  mqttClient.poll();

  // avoid having delays in loop, we'll use the strategy from BlinkWithoutDelay
  // see: File -> Examples -> 02.Digital -> BlinkWithoutDelay for more info
  unsigned long currentMillis = millis();
  
  if (currentMillis - previousMillis >= interval) {
    // save the last time a message was sent
    previousMillis = currentMillis;

    Serial.print("Sending message to topic: ");
    Serial.println(topic);
    Serial.println(String("current = ") + current + String(" temperatuur = ") + temperatuur);

    // send message, the Print interface can be used to set the message contents
    mqttClient.beginMessage(topic);
    mqttClient.print(current + String("#") + temperatuur);
    mqttClient.endMessage();
    Serial.println();
  }
}
