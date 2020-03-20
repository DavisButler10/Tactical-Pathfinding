using System.Collections.Generic;

public interface IGraph
{
    void GetCost(Node[] nodes);
    void Build();
    List<Connection> getConnections(Node fromNode);
}