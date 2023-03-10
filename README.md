# unityMQTT

Instruções de uso:

Copie o conteúdo da pasta asset para a pasta asset do seu projeto.

Clique e arraste para a cena o objeto mqttconnect.

Configure o ip e a porta para a sua aplicação.

Clique e arraste o personagem que deseja articular com sensor inercial (JAMA).

No personagem, arraste o componente requestIMUData e configure: Coloque o tópico para comandar o sensor inercial, o tempo de aquisição e a frequência de aquisição do sensor.

No requestIMUData arraste o mqttconnect também (todos compartilham o mesmo objeto).

No personagem, arraste o componente associateIMU2Segment. 

Em associateIMU2Segment, coloque o tópico para receber dados do sensor inercial, o segmento do corpo que deseja associar com o sensor e o objeto de mqtt connect (todos compartilham o mesmo objeto).


Dê play e seja feliz.
