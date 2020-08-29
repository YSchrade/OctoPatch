﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OctoPatch.Descriptions;
using OctoPatch.Setup;

namespace OctoPatch
{
    /// <summary>
    /// interface with all the methods of the patch runtime
    /// </summary>
    public interface IRuntimeMethods
    {
        #region Meta information

        /// <summary>
        /// Returns the full list of known node descriptions
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>all node descriptions</returns>
        Task<IEnumerable<NodeDescription>> GetNodeDescriptions(CancellationToken cancellationToken);

        /// <summary>
        /// Returns the full list of known message descriptions
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>all message descriptions</returns>
        Task<IEnumerable<TypeDescription>> GetMessageDescriptions(CancellationToken cancellationToken);

        #endregion

        #region Patch manipulation

        /// <summary>
        /// Returns a list of nodes
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>list of nodes</returns>
        Task<IEnumerable<NodeSetup>> GetNodes(CancellationToken cancellationToken);

        /// <summary>
        /// Returns a list of wires
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>list of wires</returns>
        Task<IEnumerable<WireSetup>> GetWires(CancellationToken cancellationToken);

        /// <summary>
        /// Returns the whole configuration
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>configuration</returns>
        Task<GridSetup> GetConfiguration(CancellationToken cancellationToken);

        /// <summary>
        /// Applies the given configuration
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <param name="grid">configuration</param>
        Task SetConfiguration(GridSetup grid, CancellationToken cancellationToken);

        /// <summary>
        /// Adds a new node to the patch
        /// </summary>
        /// <param name="key">unique key for the node description</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>new node instance</returns>
        Task<NodeSetup> AddNode(string key, CancellationToken cancellationToken);

        /// <summary>
        /// Removes the node with the given id from the patch
        /// </summary>
        /// <param name="nodeId">node id</param>
        /// <param name="cancellationToken">cancellation token</param>
        Task RemoveNode(Guid nodeId, CancellationToken cancellationToken);

        /// <summary>
        /// Adds a new wire to the patch
        /// </summary>
        /// <param name="outputNodeId">node id of the output node</param>
        /// <param name="outputConnectorId">connector id for the output</param>
        /// <param name="inputNodeId">node id of the input node</param>
        /// <param name="intputConnectorId">connector id for the input</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>new wire instance</returns>
        Task<WireSetup> AddWire(Guid outputNodeId, Guid outputConnectorId, Guid inputNodeId, Guid intputConnectorId,
            CancellationToken cancellationToken);

        /// <summary>
        /// Removes the wire with the given id
        /// </summary>
        /// <param name="wireId">wire id</param>
        /// <param name="cancellationToken">cancellation token</param>
        Task RemoveWire(Guid wireId, CancellationToken cancellationToken);

        #endregion

        #region Node configuration

        /// <summary>
        /// Sets the name and the description of a single node instance
        /// </summary>
        /// <param name="nodeGuid">guid of node</param>
        /// <param name="name">new name for this node</param>
        /// <param name="description">optional description for the block</param>
        Task SetNodeDescription(Guid nodeGuid, string name, string description);

        /// <summary>
        /// Gets the current environment information of the requested node
        /// </summary>
        /// <param name="nodeGuid">guid of node</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>serialized environment information</returns>
        Task<string> GetNodeEnvironment(Guid nodeGuid, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the configuration from the given node
        /// </summary>
        /// <param name="nodeGuid">node guid</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>serialized configuration for this node</returns>
        Task<string> GetNodeConfiguration(Guid nodeGuid, CancellationToken cancellationToken);

        /// <summary>
        /// Applies the given serialized configuration to the node
        /// </summary>
        /// <param name="nodeGuid">node guid</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <param name="configuration">configuration</param>
        Task SetNodeConfiguration(Guid nodeGuid, string configuration, CancellationToken cancellationToken);

        #endregion
    }
}
