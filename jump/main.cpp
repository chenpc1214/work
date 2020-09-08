#include <SFML/Graphics.hpp>
#include <time.h>
using namespace sf;

struct point
{ int x,y;};

int main()
{
    srand(time(0));

    RenderWindow app(VideoMode(400, 533), "jump Game!");   //限制視窗尺寸 
    app.setFramerateLimit(60);

    Texture t1,t2,t3;                                       //建立填塞物件 
    t1.loadFromFile("images/background.png");
    t2.loadFromFile("images/platform.png");
    t3.loadFromFile("images/soccer.png");

    Sprite sBackground(t1), sPlat(t2), sPers(t3);           //物件顯示 

    point plat[20];                                        //建立物件plat陣列有20個，包含x,y 

    for (int i=0;i<10;i++)                                //前十個 
      {
       plat[i].x=rand()%400;                              //在視窗寬400內隨機挑選  
       plat[i].y=rand()%533;                              //在視窗高533內隨機挑選 
      }

    int x=100,y=100,h=200;
    float dx=0,dy=0;

    while (app.isOpen())                                 //指令控制 
    {
        Event e;
        while (app.pollEvent(e))
        {
            if (e.type == Event::Closed)
                app.close();
        }

    if (Keyboard::isKeyPressed(Keyboard::Right)) x+=3;
    if (Keyboard::isKeyPressed(Keyboard::Left)) x-=3;

    dy+=0.2;                                                      
    y+=dy;
    if (y>500)  dy=-10;

    if (y<h)
    for (int i=0;i<10;i++)
    {
      y=h;                                                 //將高度給y 
      plat[i].y=plat[i].y-dy;                              //陣列中的y值減去dy 
      if (plat[i].y>533) {plat[i].y=0; plat[i].x=rand()%400;}  //如果陣列中的y值，超過視窗高度，陣列中的y歸0，x值在400中隨意取值 
    }

    for (int i=0;i<10;i++)
     if ((x+50>plat[i].x) && (x+20<plat[i].x+68)                           //繪製能踩踏的跳台：球與平台的接觸面，讓點變成線段 
      && (y+70>plat[i].y) && (y+70<plat[i].y+14) && (dy>0))  dy=-10;

    sPers.setPosition(x,y);

    app.draw(sBackground);                                //顯示背景 
    app.draw(sPers);                                      //顯示人物 
    for (int i=0;i<10;i++)                                //繪製跳台 
    {
    sPlat.setPosition(plat[i].x,plat[i].y);
    app.draw(sPlat);
    }

    app.display();                                        //顯示全部 
}

    return 0;
}
