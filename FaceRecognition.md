


# **Face Recognition, Rozpoznawanie twarzy** #
Author: <b> Marek Bar </b> <br />
Student organisation and university name: <b>Studenckie Koło Informatyków w Państwowej Wyższej Szkole Techniczno-Ekonomicznej im. ks. Bronisław Markiewicz in Jarosław </b> <br />
Scientific adviser: <b> dr. Lucjan Pelc </b> <br />

## Introduction ##

Traditional forms of application security and access to services, such as PINs, passwords and logins are vulnerable to interception by unauthorized persons, you can forget or lose the stored somewhere on a piece of paper. The other hand, are becoming increasingly popular as a security key contained in the body. The face is one of those keys. It is the unique and special for everyone. Face recognition system can be used, beyond the control of access to the database search images - such as automatic retrieval of images, where we are, or for access control, eg for areas where we should stay or not. In addition, security in the form of biological keys are much cheaper than solutions using smart cards, proximity devices or dongles on memory stick.

## Purpose of research ##

The aim of my research was to develop a method of verifying the identity of the person using the face as a biological key that is unique and easy for the casual user, because you only need to look to make the authorization.

## Material and Methods ##

The task of face detection is to divide the input data in the form of images into multiple classes, which are equivalent to people. As you know, these images may contain noise, or pixels with no link with the face. In addition, the image pixels are not entirely random. Between these areas there are random areas creating certain patterns that may indicate the presence of certain objects, such as nose, eyes or mouth, and include the relative distance between them. These characteristic patterns / features are called eigenfaces, or major components. Key features (eigenfaces) for the face are being developed using PCA (Principal Component Analysis). Each feature (eigenface) is only a representation of facial features, which can be seen in the picture or not. If the feature is present in an image more then its share in the corresponding eigenface is greater. Otherwise, when the degree of the features are almost absent or less then its share is smaller in total eigenfaces or no. Described above, part, determine the extent to which a specific characteristic is evident in obrazie.Wykorzystując all eigenfaces obtained from the input images can reproduce the original images from the eigenfaces, or make only a partial reconstruction of the image by approximation. For face recognition are important only weights obtained by the PCA algorithm. Balance means the amount of talking about it or face different from the typical face represented by the eigenfaces. Using these weights allows you to specify whether the image contains a face, and whether there are similar face to the face. This task was used OpenCV library, which has a set of APIs to perform tasks in the field of image processing.

To be able to verify the identity of operations based on facial characteristics, it requires the prior introduction of the so-called. the base face. Face database in this case is properly treated and stored images of the face only of a person and other persons who are in the database. The file names are included data on individuals whose faces are brought together in this simple database. Both the acts of his face to the base and its recognition can be divided into three common phases, listed and described below:
  1. Acquisition, the acquisition of the image. Lighting conditions and camera positioning itself affect the image, and therefore should be close to your face when you enter the database and comparing it with her.
  1. The next step is to detect faces in an image and save it in memory. Face detection is the process of finding the image of the face and returned to the position and dimensions of the surrounding area. To detect the face has been used trained Haar classifier supplied with the OpenCV library. Then adjust the size is made to the size of the detected face of the other faces in the database. If the application size is 100 pixels wide and tall. To ensure that a person's face is directed straight into the camera, is made to check the visibility of the eyes. Status of the eyelids, closed or open, it does not matter.
  1. Then, the image containing the face-found is subjected to morphological operations (pre-processing / preparation), which are designed to remove noise and unnecessary background face, uniformity of brightness. The noise added to the pixel values ​​can effectively change its meaning (which represents the information) or partial distort its meaning. Morphological operations, make the effectiveness of face recognition algorithm increases.

The preceding steps for adding images to the database is saved to a file with the appropriate name in the format: name surname number of hours minutes seconds. For each face is ten images saved face (could be more or less) to improve the effective recognition algorithm, because the face can always be at least in a different position. Enter your face to the base is easy. You just enter your details and look at the camera, and the rest will be done automatically. There is also the possibility of a face to face with the database file named in the above format, the file name. Accepted file types: png, gif, jpg, bmp.
Face recognition is a process which attempts to assign a name / ID to the face odnieseniu verified in the face of the so-called paasujących. based on the face. Face recognition uses the same method as above, but they are carried out both during the reading of the characteristics of the algorithm, with faces faces in the database, as well as for verification of the face subject to verification. Verification is intended to ascertain whether a person is in the database or not.

## Results ##

Face detection in an image obtained from the camera runs without any problems. Only people with black skin color or situated in a dark room can be not noticed. In addition, before the discovery of the face is visible eyes checked, because this is not done to get in effect a different face. Acquired facial image must be subjected to morphological operations, such as normalization or histogram, background removal, in which the face to the subsequent recognition of a person's results were correct. PCA method used to extract the essential features of the face is unfortunately susceptible to environmental conditions in which the facial image is taken for the purpose of verification of identity and should be diagnosed before the appropriate steps to prepare the image of the face to compare with the database, or prior to the base face. Properly chosen methods of implementation have a direct impact on the speed and quality of face detection. The more pictures provides the basis for the person, the more effective face recognition system is shown, because too few face shots that negatively affected the efficiency of diagnosis, or rather lack thereof.

## Discussion ##

While facial recognition, you may encounter the following error diagnosis based on:
  1. Wrong diagnosis - the attribution of the verified face to face someone who is in the database,
  1. False rejection of the face - the face occurs in the database, and is not recognized,
  1. False acceptance - face to face is assigned to someone else, despite the occurrence of this face is not in the database.

Erroneous results of face recognition using PCA is mainly due to lighting conditions when entering the user to the database as well as during image acquisition includes face to recognize. Moreover, the same background on which there is a face can be confusing for the algorithm to recognize the man. Despite these inconveniences, PCA allows for quick and positive verification of identity, provided that the earlier steps are performed in preparation for facial image recognition, so that was the least confused by the algorithm with the background.
The application demonstrates the operation of the face recognition system
As a result of seeking a solution to the verification of identity by face, was named iRecognizeYou application that uses OpenCV method implemented in the PCA and shows the face recognition system performance in the offline version. IRecognizeYou application can be downloaded from the project: http://code.google.com/p/i-recognize-you/downloads/list, where you can also browse the source code, report bugs, get all of our changes and read the theoretical description. IRecognizeYou application allows you to enter users into the database offline to face the camera and the file (after assigning an appropriate name), and of course the main feature is face detection. Operation of the most important parts of the application has been przedstawoine drawings No: 1 - Introduction and 2 - recognition. The diagram was presented the application interface.

## Summary ##

To sum up your application to face recognition based on principal component analysis (PCA) can be concluded that this method is not reliable, and despite his speed should be taken as a starting point for further research. If your face is worth the efforts directed towards the exploration ropoznawania face using a neural network that could be aided by the PCA system, or create a neural network, whose task was to determining the identity of the face based on the known face. With face recognition using PCA it is also important pre-processing, which has a large impact on the quality of diagnosis (brightness histogram equalization), but improperly chosen may worsen the results (folding).

## References ##

  1. Introduction to Face Detection and Face Recognition - Shevrim Emami from: http://www.shervinemami.info/faceRecognition.html
  1. Learning OpenCV, Computer Vision with the OpenCV Library - Gary Bradski, Adrian Kaehler

## Extras ##

### Figure 1: introduction to the so-called face. face database, the development of their own made in yEd. ###
![https://sites.google.com/site/napiszprogrampl/home/Wprowadzanie%20twarzy%20do%20bazy%20twarzy.png](https://sites.google.com/site/napiszprogrampl/home/Wprowadzanie%20twarzy%20do%20bazy%20twarzy.png)
### Figure 2: Face Detection (Initiation to the right), to develop their own made in yEd. ###
![https://sites.google.com/site/napiszprogrampl/home/Rozpoznawanie%20twarzy.png](https://sites.google.com/site/napiszprogrampl/home/Rozpoznawanie%20twarzy.png)
### Movie that shows your application ###

<a href='http://www.youtube.com/watch?feature=player_embedded&v=zi7fCxtdUKs' target='_blank'><img src='http://img.youtube.com/vi/zi7fCxtdUKs/0.jpg' width='480' height=' height=344 /></a>