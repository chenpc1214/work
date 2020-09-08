#include <SFML/Graphics.hpp>
#include <time.h>
using namespace sf;

struct point
{ int x,y;};

int main()
{
    srand(time(0));

    RenderWindow app(VideoMode(400, 533), "jump Game!");   //��������ؤo 
    app.setFramerateLimit(60);

    Texture t1,t2,t3;                                       //�إ߶�몫�� 
    t1.loadFromFile("images/background.png");
    t2.loadFromFile("images/platform.png");
    t3.loadFromFile("images/soccer.png");

    Sprite sBackground(t1), sPlat(t2), sPers(t3);           //������� 

    point plat[20];                                        //�إߪ���plat�}�C��20�ӡA�]�tx,y 

    for (int i=0;i<10;i++)                                //�e�Q�� 
      {
       plat[i].x=rand()%400;                              //�b�����e400���H���D��  
       plat[i].y=rand()%533;                              //�b������533���H���D�� 
      }

    int x=100,y=100,h=200;
    float dx=0,dy=0;

    while (app.isOpen())                                 //���O���� 
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
      y=h;                                                 //�N���׵�y 
      plat[i].y=plat[i].y-dy;                              //�}�C����y�ȴ�hdy 
      if (plat[i].y>533) {plat[i].y=0; plat[i].x=rand()%400;}  //�p�G�}�C����y�ȡA�W�L�������סA�}�C����y�k0�Ax�Ȧb400���H�N���� 
    }

    for (int i=0;i<10;i++)
     if ((x+50>plat[i].x) && (x+20<plat[i].x+68)                           //ø�s���񪺸��x�G�y�P���x����Ĳ���A���I�ܦ��u�q 
      && (y+70>plat[i].y) && (y+70<plat[i].y+14) && (dy>0))  dy=-10;

    sPers.setPosition(x,y);

    app.draw(sBackground);                                //��ܭI�� 
    app.draw(sPers);                                      //��ܤH�� 
    for (int i=0;i<10;i++)                                //ø�s���x 
    {
    sPlat.setPosition(plat[i].x,plat[i].y);
    app.draw(sPlat);
    }

    app.display();                                        //��ܥ��� 
}

    return 0;
}
