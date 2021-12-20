# Project Title

Name: Alexander Bowes
Student Number: C18727635
Course: Computer Science TU856
Module: Games Engines 1 2021/22

# Description of the project
This project is a system which demonstrates a number of procedurally generated elements. 
The project consists of a procedurally generated desert using perlin noise which can be navigated 
through using a first person camera.

If the player chooses to, they may move through the world and leave the starting area to continue
walking infinitely through the desert. As the player moves, new tiles of land will be procedurally generated ahead of
them, giving the impression of a never ending desert.

As well as the desert, there are game objects which have been 
instantiated in different patterns such as spirals and rings. When the player opens the project they
will see the camera is positioned in the center of a ring of cacti. The cacti game models were created
using Blender. 

As mentioned, other game objects have been instantiated in patterns, most notably the spiral of icospheres
which move in accordance to the song which plays when the project begins. 

Scripts have been written for icospheres, pyramids and flattened cubes to respond and move in accordance to the song which 
plays.

Color lerping has also been implemented which gradually changes the colors of the icospheres and flattened cubes over time.

Pyramids also respond to the audio and move through the spiral in response to the music.

I intend to have this project give the user an impression that they are seeing something which resembles
a science fiction movie with space ships and portals being discovered in a desert.

![Image1 of project](pictures/MyProject1.PNG)


![Image2 of project](pictures/MyProject2.PNG)


![Image3 of project](pictures/MyProject3.PNG)


I think this project resembles something from the show Stargate:

![stargate inspiration](pictures/Stargate.PNG)



# Instructions for use

The version of Unity which this project was created with was: 2020.3.19f1

The user can control the camera by moving the mouse in the dircention which they want to look at.
Moving the character:
- Press W key = Move forward
- Press S key = Move backward
- Press A key = strafe left
- Press D key = strafe right

# How it works

This project consists of key features:
- A Procedural, infinite desert
- Procedural, spiral of icospheres
- Instantiated pyramids
- Ring of Cacti
- Color Lerping


The procedural desert was the first feature I set out to create. 
A single plane of land had to be created, this game object was called "Smart Plane" which was created
from a "plane" game object which means it holds the mesh of a Plane.

A smart plane had to be created with the perlin noise function, the reason for this is because 
Perlin noise allows for pseudo-random gradient noise and gradual transitions between peaks and troughs when creating
uneven terrain such as sand in a desert.  

This is shown in the start() function of "GenerateTerrain" which is responsible for creating 
an individual desert plane using perline noise:

```    void Start()
    {
        //get the plane mesh filter
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        //for each vertex in the plane..
        for(int v = 0; v < vertices.Length; v++)
        {
            //assign the height of the vertex to be a value random value that allows for smooth transition when joining 2 planes
            vertices[v].y = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x)/detailScale,
                     (vertices[v].z + this.transform.position.z)/detailScale)*heightScale;
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        //update the normals after modifying the vertices
        mesh.RecalculateNormals();
        //allow for collision on the plane
        this.gameObject.AddComponent<MeshCollider>();
        
    }
```


# List of classes/assets in the project and whether made yourself or modified or if its from a source, please give the reference

| Class/asset | Source |
|-----------|-----------|
| MyClass.cs | Self written |
| MyClass1.cs | Modified from [reference]() |
| MyClass2.cs | From [reference]() |

# References

# What I am most proud of in the assignment

# Proposal submitted earlier can go here:

## This is how to markdown text:

This is *emphasis*

This is a bulleted list

- Item
- Item

This is a numbered list

1. Item
1. Item

This is a [hyperlink](http://bryanduggan.org)

# Headings
## Headings
#### Headings
##### Headings

This is code:

```Java
public void render()
{
	ui.noFill();
	ui.stroke(255);
	ui.rect(x, y, width, height);
	ui.textAlign(PApplet.CENTER, PApplet.CENTER);
	ui.text(text, x + width * 0.5f, y + height * 0.5f);
}
```

So is this without specifying the language:

```
public void render()
{
	ui.noFill();
	ui.stroke(255);
	ui.rect(x, y, width, height);
	ui.textAlign(PApplet.CENTER, PApplet.CENTER);
	ui.text(text, x + width * 0.5f, y + height * 0.5f);
}
```

This is an image using a relative URL:

![An image](images/p8.png)

This is an image using an absolute URL:

![A different image](https://bryanduggandotorg.files.wordpress.com/2019/02/infinite-forms-00045.png?w=595&h=&zoom=2)

This is a youtube video:

[![YouTube](http://img.youtube.com/vi/J2kHSSFA4NU/0.jpg)](https://www.youtube.com/watch?v=J2kHSSFA4NU)

This is a table:

| Heading 1 | Heading 2 |
|-----------|-----------|
|Some stuff | Some more stuff in this column |
|Some stuff | Some more stuff in this column |
|Some stuff | Some more stuff in this column |
|Some stuff | Some more stuff in this column |

