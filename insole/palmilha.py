import paho.mqtt.client as mqtt
import json, math,time
from datetime import datetime
numero = "3952"
#calcâneo 1, calcâneo 2, Meta2, Médiopé, Meta1, hálux 
class saveIMUMQTTData(mqtt.Client):
    def requestIMUStream(self):
        msg2send = {'op':28}
        msg2send['timeout'] = 6000
        msg2send['frequence'] = 20
        print('requestIMUStream: ', "cmd2dev"+numero)
        print(json.dumps(msg2send))
        self.publish("cmd2dev"+numero,json.dumps(msg2send))

    def stopIMUStream(self):
        msg2send = {'op':22}
        self.publish("cmd2dev"+numero,json.dumps(msg2send))
    
    def streamReceivedData(self,msg):
        data = msg.payload.decode('utf8')
        return data

    def connectSensor(self):
        self.connect('10.1.1.243', 1883, 600)
        self.counter = 0
        rc = 0
        while rc == 0:
            rc = self.loop()
        return rc

    def startExperiment(self):
        print('Request Start')
        now = datetime.now() # current date and time
        date_time = now.strftime("%m_%d_%Y_%H_%M_%S")
        self.file = open("experiment_" + date_time + ".csv", "w")
        self.file.write("Walk experiment on date "+date_time+"\n Input Paremeters:\nsensor = "+numero+", frequence = "+str(20)+"\n\n")
        self.requestIMUStream()

    def on_connect(self, mqttc, obj, flags, rc):
        print("Connected with result code "+str(rc))
        self.subscribe("dev"+numero+"ss")
        self.startExperiment()
    
    def on_connect_fail(self, mqttc, obj):
        print("Connect failed")
        self.connect('10.1.1.243', 1883, 600)
        

    def on_message(self, mqttc, obj, msg):
        t_epoch = time.time()
        now = datetime.now() # current date and time
        data2save = now.strftime("%m/%d/%Y_%H:%M:%S, ") + msg.payload.decode('utf8').split('\n')[0]+'\n'
        self.file.write(data2save)
        self.counter += 1
        if self.counter % 20 ==0:
            print(data2save)
          
imusave = saveIMUMQTTData()
imusave.connectSensor()