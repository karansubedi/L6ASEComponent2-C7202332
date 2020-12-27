using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Component2
{
    /// <summary>
    /// To parse Commands according to data entered user enter
    /// </summary>
    public class commandParser
    {
        int numberOfLine = 0;



        /// <summary>
        /// Method to parse methods provided by user
        /// </summary>
        /// <param name="data"></param>
        /// <param name="newDrawing"></param>
        /// <param name="n"></param>
        /// <param name="z"></param>
        public void parseMethod(List<String> data, Drawing newDrawing, int n, int z)
        {
            string tempData = string.Join("\n", data);
            String[] value = tempData.Split('\n');
            String[] command = value[0].Split(' ');
            String x = null;
            bool variable = false;
            String[] methodCommand = command[1].Split('(', ')');
            String[] methodValue = null;

            newDrawing.m.storeMethod(methodCommand[0], methodCommand[1]);

            List<String> dataList = new List<String>();
            int y = 1;
            while (y < value.Length)
            {
                dataList.Add(value[y]);
                y++;
            }

            try
            {
                if (newDrawing.m.existingMethod(methodCommand[0]))
                {
                    x = newDrawing.m.getMethod(methodCommand[0]);
                    methodValue = x.Split(',');
                }
                else
                {
                    variable = true;
                }
                if (variable)
                {
                    newDrawing.commandCheck.Parameterscheck(false, command[1], n, newDrawing, numberOfLine);
                    numberOfLine = numberOfLine + 20;
                }
                else
                {
                    tempData = string.Join("\n", dataList);
                    string commandmethod = methodCommand[0] + "command";
                    newDrawing.m.storeMethod(commandmethod, tempData);
                }
            }
            catch
            {
                newDrawing.commandCheck.Parameterscheck(false, "", n - z, newDrawing, numberOfLine);
                numberOfLine = numberOfLine + 20;
            }
        }



        /// <summary>
        /// method created for "for" loop
        /// </summary>
        /// <param name="data">user input data for 'if' condition</param>
        /// <param name="newCanvass">displaying screen in which user given instructions is implemented</param>
        /// <param name="n">line where the program is currently running</param>
        /// <param name="z"></param>
        public void loop(List<String> data, Drawing newDrawing, int n, int z)
        {
            string tempData = string.Join("\n", data);
            String[] value = tempData.Split('\n');
            String[] command = value[0].Split(' ');
            int x = 0;
            bool variable = false;
            List<String> dataList = new List<String>();
            int y = 1;
            while (y < value.Length)
            {
                dataList.Add(value[y]);
                y++;
            }

            try
            {
                if (command[1].Equals("for"))
                {
                    if (!int.TryParse(command[2], out x))
                    {
                        if (!newDrawing.v.exisitingVariable(command[2]))
                        {
                            variable = true;
                        }

                        else
                        {
                            x = newDrawing.v.pullData(command[2]);
                        }
                    }

                }

                if (variable)
                {
                    newDrawing.commandCheck.Parameterscheck(false, command[2], n, newDrawing, numberOfLine);
                    numberOfLine = numberOfLine + 20;
                }
                else
                {
                    for (int b = 0; b < x; b++)
                    {
                        tempData = string.Join("\n", dataList);
                        multiplecommands(tempData, newDrawing);
                    }
                }
            }

            catch
            {
                newDrawing.commandCheck.Parameterscheck(false, "", n - z, newDrawing, numberOfLine);
                numberOfLine = numberOfLine + 20;
            }

        }



        public void condition(List<String> data, Drawing newDrawing, int n, int z)
        {
            string tempData = string.Join("\n", data);
            String[] value = tempData.Split('\n');
            String[] command = value[0].Split(' ');
            int x = 0;
            bool variable = false;
            List<String> dataList = new List<String>();
            int y = 1;
            while (y < value.Length)
            {
                dataList.Add(value[y]);
                y++;
            }

            try
            {
                if (command[1].Split('<').Length > 1)
                {
                    String[] tempValue = command[1].Split('<');

                    if (!int.TryParse(tempValue[1], out x))
                    {
                        if (!newDrawing.v.exisitingVariable(tempValue[1]))
                        {
                            variable = true;
                        }
                        else
                        {
                            x = newDrawing.v.pullData(tempValue[1]);
                        }
                    }

                    if (variable)
                    {
                        newDrawing.commandCheck.Parameterscheck(false, tempValue[1], n, newDrawing, numberOfLine);
                        numberOfLine = numberOfLine + 20;
                    }
                    else
                    {
                        if (!newDrawing.v.exisitingVariable(tempValue[0]))
                        {
                            variable = true;
                        }
                        if (variable)
                        {
                            newDrawing.commandCheck.Parameterscheck(false, tempValue[0], n, newDrawing, numberOfLine);
                            numberOfLine = numberOfLine + 20;
                        }
                        else
                        {
                            if (newDrawing.v.pullData(tempValue[0]) < x)
                            {
                                tempData = string.Join("\n", dataList);
                                multiplecommands(tempData, newDrawing);
                            }
                        }
                    }


                }
                else if (command[1].Split('>').Length > 1)
                {
                    String[] Value = command[1].Split('>');
                    if (!int.TryParse(Value[1], out x))
                    {
                        if (!newDrawing.v.exisitingVariable(Value[1]))
                        {
                            variable = true;
                        }
                        else
                        {
                            x = newDrawing.v.pullData(Value[1]);
                        }
                    }
                    if (variable)
                    {
                        newDrawing.commandCheck.Parameterscheck(false, Value[1], n, newDrawing, numberOfLine);
                        numberOfLine = numberOfLine + 20;
                    }
                    else
                    {
                        if (!newDrawing.v.exisitingVariable(Value[0]))
                        {
                            variable = true;
                        }
                        if (variable)
                        {
                            newDrawing.commandCheck.Parameterscheck(false, Value[0], n, newDrawing, numberOfLine);
                            numberOfLine = numberOfLine + 20;
                        }
                        else
                        {
                            if (newDrawing.v.pullData(Value[0]) > x)
                            {
                                tempData = string.Join("\n", dataList);
                                multiplecommands(tempData, newDrawing);
                            }
                        }
                    }
                }

                else if (command[1].Split('=').Length > 1)
                {
                    String[] tempValue = command[1].Split('=');

                    if (!int.TryParse(tempValue[2], out x))
                    {
                        if (!newDrawing.v.exisitingVariable(tempValue[2]))
                        {
                            variable = true;
                        }
                        else
                        {
                            x = newDrawing.v.pullData(tempValue[2]);
                        }
                    }
                    if (variable)
                    {
                        newDrawing.commandCheck.Parameterscheck(false, tempValue[2], n, newDrawing, numberOfLine);
                        numberOfLine = numberOfLine + 20;
                    }
                    else
                    {
                        if (!newDrawing.v.exisitingVariable(tempValue[0]))
                        {
                            variable = true;
                        }
                        if (variable)
                        {
                            newDrawing.commandCheck.Parameterscheck(false, tempValue[0], n, newDrawing, numberOfLine);
                            numberOfLine = numberOfLine + 20;
                        }
                        else
                        {
                            while (newDrawing.v.pullData(tempValue[0]) == x)
                            {
                                tempData = string.Join("\n", dataList);
                                multiplecommands(tempData, newDrawing);
                            }
                        }
                    }
                }
                else
                {
                    newDrawing.commandCheck.Parameterscheck(false, "", n - z, newDrawing, numberOfLine);
                    numberOfLine = numberOfLine + 20;
                }


            }
            catch
            {
                newDrawing.commandCheck.Parameterscheck(false, "", n - z, newDrawing, numberOfLine);
                numberOfLine = numberOfLine + 20;
            }

        }

        /// <summary>
        /// Read the single Lne Command
        /// </summary>
        /// <param name="command"></param>
        /// <param name="newDrawing"></param>
        public void CommandLine(String command, Drawing newDrawing)
        {
            String[] split = command.Split(' ');
            CommandsEntered(split, newDrawing, -1);


        }
        /// <summary>
        /// Parse multiple Lines
        /// </summary>
        /// <param name="command"></param>
        /// <param name="newDrawing"></param>
        public void multiplecommands(String command, Drawing newDrawing)
        {
            String[] split = command.Split('\n');
            int n = 0;
            int x = 0;
            while (n < split.Length)
            {
                String[] splitCommand = split[n].Split(' ');
                if (splitCommand[0].Equals("loop"))
                {
                    List<String> data = new List<string>();
                    do
                    {
                        x++;
                        data.Add(split[n]);
                        n++;
                        splitCommand = split[n].Split(' ');
                    }
                    while (!splitCommand[0].Equals("endfor"));
                    loop(data, newDrawing, n, x);
                }

                else if (splitCommand[0].Equals("if"))
                {
                    List<String> data = new List<string>();

                    do
                    {
                        x++;
                        data.Add(split[n]);
                        n++;
                        splitCommand = split[n].Split(' ');
                    }
                    while (!splitCommand[0].Equals("endif"));
                    condition(data, newDrawing, n, x);
                }
                else if (splitCommand[0].Equals("method"))
                {
                    List<String> data = new List<string>();
                    do
                    {
                        x++;
                        data.Add(split[n]);
                        n++;
                        splitCommand = split[n].Split(' ');
                    }
                    while (!splitCommand[0].Equals("endmethod"));
                    parseMethod(data, newDrawing, n, x);
                }
                else
                {
                    CommandsEntered(splitCommand, newDrawing, n);
                }
                n++;

            }
        }

        /// <summary>
        /// To read multiple line and single line commands
        /// </summary>
        /// <param name="command"></param>
        /// <param name="multiline"></param>
        /// <param name="NewDrawing"></param>
        public void Commands(String command, String multiline, Drawing NewDrawing)
        {
            if (NewDrawing.error)
            {
                NewDrawing.reset();
                NewDrawing.error = false;
            }
            if (multiline.Length.Equals(0))
            {
                CommandLine(command, NewDrawing);
            }
            else if (command.Equals("run"))
            {
                multiplecommands(multiline, NewDrawing);
            }
            else
            {
                multiplecommands(multiline, NewDrawing);
            }
        }

        /// <summary>
        /// To Check the user entered commands
        /// </summary>
        /// <param name="split"></param>
        /// <param name="newDrawing"></param>
        /// <param name="x"></param>
        public void CommandsEntered(String[] split, Drawing newDrawing, int n)
        {
            commandCheck commandCheck = new commandCheck();
            try
            {
                String[] method = split[0].Split('(', ')');


                //Checking entered commands and having their outputs
                if (split[0].Equals("moveto"))
                {
                    String[] parameters = split[1].Split(',');
                    int x = 0;
                    int y = 0;
                    bool parameter = false;

                    try
                    {
                        if (!int.TryParse(parameters[0], out x))
                        {
                            if (!newDrawing.v.exisitingVariable(parameters[0]))
                            {
                                parameter = true;
                            }
                            else
                            {
                                x = newDrawing.v.pullData(parameters[0]);
                            }
                            if (parameter)
                            {
                                newDrawing.commandCheck.Parameterscheck(false, parameters[0], n, newDrawing, numberOfLine);
                                numberOfLine = numberOfLine + 20;
                            }


                        }
                        if (!int.TryParse(parameters[1], out y))
                        {
                            if (!newDrawing.v.exisitingVariable(parameters[1]))
                            {
                                parameter = true;
                            }
                            else
                            {
                                y = newDrawing.v.pullData(parameters[1]);
                            }
                            if (parameter)
                            {
                                newDrawing.commandCheck.Parameterscheck(false, parameters[1], n, newDrawing, numberOfLine);
                                numberOfLine = numberOfLine + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        newDrawing.commandCheck.Parameterscheck(e, newDrawing, n, numberOfLine);
                        numberOfLine = numberOfLine + 20;
                    }
                    if (!newDrawing.error)
                    {
                        newDrawing.moveTo(x, y);
                    }
                }

                else if (split[0].Equals("drawto"))
                {
                    String[] data = split[1].Split(',');
                    int x = 0;
                    int y = 0;
                    bool variable = false;

                    try
                    {
                        if (!int.TryParse(data[0], out x))
                        {
                            if (!newDrawing.v.exisitingVariable(data[0]))
                            {
                                variable = true;
                            }
                            else
                            {
                                x = newDrawing.v.pullData(data[0]);
                            }
                            if (variable)
                            {
                                newDrawing.commandCheck.Parameterscheck(false, data[0], n, newDrawing, numberOfLine);
                                numberOfLine = numberOfLine + 20;
                            }
                        }
                        if (!int.TryParse(data[1], out y))
                        {
                            if (!newDrawing.v.exisitingVariable(data[1]))
                            {
                                variable = true;
                            }
                            else
                            {
                                y = newDrawing.v.pullData(data[1]);
                            }
                            if (variable)
                            {
                                newDrawing.commandCheck.Parameterscheck(false, data[1], n, newDrawing, numberOfLine);
                                numberOfLine = numberOfLine + 20;
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        newDrawing.commandCheck.Parameterscheck(e, newDrawing, n, numberOfLine);
                        numberOfLine = numberOfLine + 20;
                    }
                    if (!newDrawing.error)
                    {
                        newDrawing.drawTo(x, y);
                    }

                }

                else if (split[0].Equals("polygon"))
                {
                    String[] data = split[1].Split(',');
                    List<int> tempPoints = new List<int>();
                    int i = 0;
                    int x = 0;
                    int y = 0;
                    int z = 0;
                    bool var = false;

                    try
                    {
                        while (data.Length > i)
                        {
                            if (!int.TryParse(data[i], out x))
                            {
                                if (!newDrawing.v.exisitingVariable(data[i]))
                                {
                                    var = true;
                                }
                                else
                                {
                                    tempPoints.Add(newDrawing.v.pullData(data[i]));
                                }
                                if (var)
                                {
                                    newDrawing.commandCheck.Parameterscheck(false, data[i], n, newDrawing, numberOfLine);
                                    numberOfLine = numberOfLine + 20;
                                }
                            }
                            tempPoints.Add(x);
                            i++;
                        }

                    }
                    catch (Exception e)
                    {
                        newDrawing.commandCheck.Parameterscheck(e, newDrawing, n, numberOfLine);
                        numberOfLine = numberOfLine + 20;
                    }
                    if (!newDrawing.error)
                    {
                        int[] arr = tempPoints.ToArray();
                        Shape polygon = new DrawPolygon(arr);
                        polygon.draw(newDrawing);
                    }
                }

                else if (split[0].Equals("rectangle"))
                {
                    String[] data = split[1].Split(',');
                    int w = 0;
                    int h = 0;

                    bool variable = false;

                    try
                    {
                        if (!int.TryParse(data[0], out w))
                        {
                            if (!newDrawing.v.exisitingVariable(data[0]))
                            {
                                variable = true;
                            }
                            else
                            {
                                w = newDrawing.v.pullData(data[0]);
                            }
                            if (variable)
                            {
                                newDrawing.commandCheck.Parameterscheck(false, data[0], n, newDrawing, numberOfLine);
                                numberOfLine = numberOfLine + 20;
                            }
                        }

                        if (!int.TryParse(data[1], out h))
                        {
                            if (!newDrawing.v.exisitingVariable(data[1]))
                            {
                                variable = true;
                            }
                            else
                            {
                                h = newDrawing.v.pullData(data[1]);
                            }
                            if (variable)
                            {
                                newDrawing.commandCheck.Parameterscheck(false, data[1], n, newDrawing, numberOfLine);
                                numberOfLine = numberOfLine + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        newDrawing.commandCheck.Parameterscheck(e, newDrawing, n, numberOfLine);
                        numberOfLine = numberOfLine + 20;
                    }
                    if (!newDrawing.error)
                    {
                        Shape rectangle = new DrawRectangle(w, h);
                        rectangle.draw(newDrawing);
                    }


                }

                else if (split[0].Equals("square"))
                {
                    String[] data = split[1].Split(',');
                    int s = 0;

                    bool variable = false;

                    try
                    {
                        if (!int.TryParse(data[0], out s))
                        {
                            if (!newDrawing.v.exisitingVariable(data[0]))
                            {
                                variable = true;
                            }
                            else
                            {
                                s = newDrawing.v.pullData(data[0]);
                            }
                            if (variable)
                            {
                                newDrawing.commandCheck.Parameterscheck(false, data[0], n, newDrawing, numberOfLine);
                                numberOfLine = numberOfLine + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        newDrawing.commandCheck.Parameterscheck(e, newDrawing, n, numberOfLine);
                        numberOfLine = numberOfLine + 20;
                    }
                    if (!newDrawing.error)
                    {
                        Shape square = new DrawRectangle(s, s);
                        square.draw(newDrawing);
                    }
                }

                else if (split[0].Equals("circle"))
                {
                    String[] data = split[1].Split(',');
                    int r = 0;
                    bool variable = false;
                    try
                    {
                        if (!int.TryParse(data[0], out r))
                        {
                            if (!newDrawing.v.exisitingVariable(data[0]))
                            {
                                variable = true;
                            }
                            else
                            {
                                r = newDrawing.v.pullData(data[0]);
                            }
                            if (variable)
                            {
                                newDrawing.commandCheck.Parameterscheck(false, data[0], n, newDrawing, numberOfLine);
                                numberOfLine = numberOfLine + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        newDrawing.commandCheck.Parameterscheck(e, newDrawing, n, numberOfLine);
                        numberOfLine = numberOfLine + 20;
                    }
                    if (!newDrawing.error)
                    {
                        Shape circle = new DrawCircle(r);
                        circle.draw(newDrawing);
                    }
                }

                else if (split[0].Equals("triangle"))
                {
                    String[] data = split[1].Split(',');
                    int h = 0;
                    int b = 0;
                    int a = 0;

                    bool variable = false;
                    try
                    {
                        if (!int.TryParse(data[0], out h))
                        {
                            if (!newDrawing.v.exisitingVariable(data[0]))
                            {
                                variable = true;
                            }
                            else
                            {
                                h = newDrawing.v.pullData(data[0]);
                            }
                            if (variable)
                            {
                                newDrawing.commandCheck.Parameterscheck(false, data[0], n, newDrawing, numberOfLine);
                                numberOfLine = numberOfLine + 20;
                            }
                        }

                        if (!int.TryParse(data[1], out b))
                        {
                            if (!newDrawing.v.exisitingVariable(data[1]))
                            {
                                variable = true;
                            }
                            else
                            {
                                b = newDrawing.v.pullData(data[1]);
                            }
                            if (variable)
                            {
                                newDrawing.commandCheck.Parameterscheck(false, data[1], n, newDrawing, numberOfLine);
                                numberOfLine = numberOfLine + 20;
                            }

                        }

                        if (!int.TryParse(data[0], out a))
                        {
                            if (!newDrawing.v.exisitingVariable(data[0]))
                            {
                                variable = true;
                            }
                            else
                            {
                                a = newDrawing.v.pullData(data[0]);
                            }
                            if (variable)
                            {
                                newDrawing.commandCheck.Parameterscheck(false, data[0], n, newDrawing, numberOfLine);
                                numberOfLine = numberOfLine + 20;
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        newDrawing.commandCheck.Parameterscheck(e, newDrawing, n, numberOfLine);
                        numberOfLine = numberOfLine + 20;
                    }
                    if (!newDrawing.error)
                    {
                        Shape triangle = new DrawTriangle(h, b, a);
                        triangle.draw(newDrawing);
                    }
                }

                else if (split[0].Equals("pen"))
                {
                    Color pencolor = Color.FromName(split[1]);
                    if (pencolor.IsKnownColor == false)
                    {
                        commandCheck.Parameterscheck(false, split[1], n, newDrawing, numberOfLine);
                        numberOfLine = numberOfLine + 20;
                    }
                    if (!newDrawing.error)
                    {
                        newDrawing.set_penColor(pencolor);
                    }
                }

                else if (split[0].Equals("fill"))
                {
                    bool valueOn = split[1].Equals("on");
                    bool valueOff = split[1].Equals("off");

                    if (valueOn == false && valueOff == false)
                    {
                        commandCheck.Parameterscheck(false, split[1], n, newDrawing, numberOfLine);
                        numberOfLine = numberOfLine + 20;

                    }
                    if (!newDrawing.error)
                    {
                        if (valueOn)
                        {
                            newDrawing.fill = true;
                        }
                        else if (valueOff)
                        {
                            newDrawing.fill = false;
                        }
                    }
                }

                else if (split[0].Equals("reset"))
                {
                    newDrawing.reset();
                }

                else if (split[0].Equals("clear"))
                {
                    newDrawing.clear();
                }

                else if (split[0].Equals("exit"))
                {
                    Application.Exit();
                }

                else if (newDrawing.m.existingMethod(method[0]))
                {
                    String[] methodValue = (newDrawing.m.getMethod(method[0])).Split(',');
                    String methodCmd = method[0] + "command";
                    String methodCommand = newDrawing.m.getMethod(methodCmd);
                    String[] userValue = method[1].Split(',');
                    int x = 0;
                    while (methodValue.Length > x)
                    {
                        String[] valueStore = (methodValue[x] + "=" + userValue[x]).Split(' ');
                        CommandsEntered(valueStore, newDrawing, n);
                        x++;
                    }
                    multiplecommands(methodCommand, newDrawing);
                }

                else if (split[1].Equals("="))
                {
                    try
                    {
                        if (split[3].Equals("+"))
                        {
                            int variableValue;
                            int x = 0;
                            int y = 0;
                            bool variable = false;
                            try
                            {
                                if (!int.TryParse(split[2], out x))
                                {
                                    if (!newDrawing.v.exisitingVariable(split[2]))
                                    {
                                        variable = true;
                                    }
                                    else
                                    {
                                        x = newDrawing.v.pullData(split[2]);
                                    }
                                }
                                if (!int.TryParse(split[4], out y))
                                {
                                    if (!newDrawing.v.exisitingVariable(split[4]))
                                    {
                                        variable = true;
                                    }
                                    else
                                    {
                                        y = newDrawing.v.pullData(split[4]);
                                    }
                                }
                                if (variable)
                                {
                                    commandCheck.Parameterscheck(false, split[2], n, newDrawing, numberOfLine);
                                    numberOfLine = numberOfLine + 20;
                                }
                            }
                            catch (Exception e)
                            {
                                commandCheck.Parameterscheck(e, newDrawing, n, numberOfLine);
                                numberOfLine = numberOfLine + 20;
                            }
                            variableValue = x + y;
                            newDrawing.v.UpdateVariable(split[0], variableValue);
                        }

                        if (split[3].Equals("*"))
                        {
                            int variableValue;
                            int x = 0;
                            int y = 0;
                            bool variable = false;

                            try
                            {
                                if (!int.TryParse(split[2], out x))
                                {
                                    if (!newDrawing.v.exisitingVariable(split[2]))
                                    {
                                        variable = true;
                                    }
                                    else
                                    {
                                        x = newDrawing.v.pullData(split[2]);
                                    }
                                }
                                if (!int.TryParse(split[4], out y))
                                {
                                    if (!newDrawing.v.exisitingVariable(split[4]))
                                    {
                                        variable = true;
                                    }
                                    else
                                    {
                                        y = newDrawing.v.pullData(split[4]);
                                    }
                                }
                                if (variable)
                                {
                                    commandCheck.Parameterscheck(false, split[2], n, newDrawing, numberOfLine);
                                    numberOfLine = numberOfLine + 20;
                                }
                            }
                            catch (Exception e)
                            {
                                commandCheck.Parameterscheck(e, newDrawing, n, numberOfLine);
                                numberOfLine = numberOfLine + 20;
                            }
                            variableValue = x * y;
                            newDrawing.v.UpdateVariable(split[0], variableValue);
                        }

                        if (split[3].Equals("-"))
                        {
                            int variableValue;
                            int x = 0;
                            int y = 0;
                            bool variable = false;

                            try
                            {
                                if (!int.TryParse(split[2], out x))
                                {
                                    if (!newDrawing.v.exisitingVariable(split[2]))
                                    {
                                        variable = true;
                                    }
                                    else
                                    {
                                        x = newDrawing.v.pullData(split[2]);
                                    }
                                }

                                if (!int.TryParse(split[4], out y))
                                {
                                    if (!newDrawing.v.exisitingVariable(split[4]))
                                    {
                                        variable = true;
                                    }
                                    else
                                    {
                                        y = newDrawing.v.pullData(split[4]);
                                    }
                                }

                                if (variable)
                                {
                                    commandCheck.Parameterscheck(false, split[2], n, newDrawing, numberOfLine);
                                    numberOfLine = numberOfLine + 20;
                                }
                            }

                            catch (Exception e)
                            {
                                commandCheck.Parameterscheck(e, newDrawing, n, numberOfLine);
                                numberOfLine = numberOfLine + 20;
                            }
                            variableValue = x - y;
                            newDrawing.v.UpdateVariable(split[0], variableValue);
                        }

                        if (split[3].Equals("/"))
                        {
                            int variableValue;
                            int x = 0;
                            int y = 0;
                            bool variable = false;

                            try
                            {
                                if (!int.TryParse(split[2], out x))
                                {
                                    if (!newDrawing.v.exisitingVariable(split[2]))
                                    {
                                        variable = true;
                                    }
                                    else
                                    {
                                        x = newDrawing.v.pullData(split[2]);
                                    }
                                }
                                if (!int.TryParse(split[4], out y))
                                {
                                    if (!newDrawing.v.exisitingVariable(split[4]))
                                    {
                                        variable = true;
                                    }
                                    else
                                    {
                                        y = newDrawing.v.pullData(split[4]);
                                    }
                                }
                                if (variable)
                                {
                                    commandCheck.Parameterscheck(false, split[2], n, newDrawing, numberOfLine);
                                    numberOfLine = numberOfLine + 20;
                                }
                            }
                            catch (Exception e)
                            {
                                commandCheck.Parameterscheck(e, newDrawing, n, numberOfLine);
                                numberOfLine = numberOfLine + 20;
                            }
                            variableValue = x / y;
                            newDrawing.v.UpdateVariable(split[0], variableValue);
                        }
                    }
                    catch
                    {
                        int x = 0;

                        try
                        {
                            bool variable = false;
                            if (!int.TryParse(split[2], out x))
                            {
                                if (!newDrawing.v.exisitingVariable(split[2]))
                                {
                                    variable = true;
                                }
                                else
                                {
                                    x = newDrawing.v.pullData(split[2]);
                                }
                                if (variable)
                                {
                                    newDrawing.commandCheck.Parameterscheck(false, split[2], n, newDrawing, numberOfLine);
                                    numberOfLine = numberOfLine + 20;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            newDrawing.commandCheck.Parameterscheck(e, newDrawing, n, numberOfLine);
                            numberOfLine = numberOfLine + 20;
                        }
                        if (!newDrawing.error)
                        {
                            if (!newDrawing.v.exisitingVariable(split[0]))
                            {
                                newDrawing.v.storeData(split[0], x);
                            }
                            else
                            {
                                newDrawing.v.UpdateVariable(split[0], x);
                            }
                        }
                    }
                }
                else
                {
                    commandCheck.Commands_Check(newDrawing, n, numberOfLine);
                    numberOfLine = numberOfLine + 20;
                }
            }
            catch
            {
                commandCheck.Commands_Check(newDrawing, n, numberOfLine);
                numberOfLine = numberOfLine + 20;
            }
        }


    }
}
