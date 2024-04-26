﻿using OpenAI.Extensions;
using OpenAI.Interfaces;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels.ResponseModels;
using OpenAI.ObjectModels.SharedModels;

namespace OpenAI.Managers;

public partial class OpenAIService : IRunService
{
    /// <summary>
    ///     Create a run.
    /// </summary>
    /// <param name="threadId"></param>
    /// <param name="request"></param>
    /// <param name="modelId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<RunResponse> RunCreate(string threadId, RunCreateRequest request, string? modelId = null, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(threadId))
        {
            throw new ArgumentNullException(nameof(threadId));
        }

        request.ProcessModelId(modelId, _defaultModelId,true);
        return await _httpClient.PostAndReadAsAsync<RunResponse>(_endpointProvider.RunCreate(threadId), request, cancellationToken);
    }

    /// <summary>
    ///     Retrieves a run.
    /// </summary>
    /// <param name="threadId"></param>
    /// <param name="runId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<RunResponse> RunRetrieve(string threadId, string runId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(threadId))
        {
            throw new ArgumentNullException(nameof(threadId));
        }

        if (string.IsNullOrWhiteSpace(runId))
        {
            throw new ArgumentNullException(nameof(runId));
        }

        return await _httpClient.GetReadAsAsync<RunResponse>(_endpointProvider.RunRetrieve(threadId, runId), cancellationToken);
    }

    /// <summary>
    ///     Cancels a run that is in_progress.
    /// </summary>
    /// <param name="threadId"></param>
    /// <param name="runId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<RunResponse> RunCancel(string threadId, string runId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(threadId))
        {
            throw new ArgumentNullException(nameof(threadId));
        }

        return await _httpClient.PostAndReadAsAsync<RunResponse>(_endpointProvider.RunCancel(threadId, runId), null, cancellationToken);
    }

    /// <summary>
    ///     Submit tool outputs to run
    ///     <para>
    ///         When a run has the status: "requires_action" and required_action.type is submit_tool_outputs,
    ///         this endpoint can be used to submit the outputs from the tool calls once they're all completed.
    ///         All outputs must be submitted in a single request.
    ///     </para>
    /// </summary>
    /// <param name="threadId"></param>
    /// <param name="runId"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<RunResponse> RunSubmitToolOutputs(string threadId, string runId, SubmitToolOutputsToRunRequest request, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(threadId))
        {
            throw new ArgumentNullException(nameof(threadId));
        }

        if (string.IsNullOrWhiteSpace(runId))
        {
            throw new ArgumentNullException(nameof(runId));
        }

        return await _httpClient.PostAndReadAsAsync<RunResponse>(_endpointProvider.RunSubmitToolOutputs(threadId, runId), request, cancellationToken);
    }

    /// <summary>
    ///     Retrieves the list of run steps belonging to a run.
    /// </summary>
    /// <param name="threadId"></param>
    /// <param name="runId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<RunStepListResponse> RunStepList(string threadId, string runId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(threadId))
            throw new ArgumentNullException(nameof(threadId));

        if (string.IsNullOrWhiteSpace(runId))
            throw new ArgumentNullException(nameof(runId));

        return await _httpClient.GetReadAsAsync<RunStepListResponse>(_endpointProvider.RunStepList(threadId, runId, null), cancellationToken);
    }

    /// <summary>
    ///     Retrieve a run step.
    /// </summary>
    /// <param name="threadId"></param>
    /// <param name="runId"></param>
    /// /// <param name="stepId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<RunStepResponse> RunStepRetrieve(string threadId, string runId, string stepId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(threadId))
            throw new ArgumentNullException(nameof(threadId));

        if (string.IsNullOrWhiteSpace(runId))
            throw new ArgumentNullException(nameof(runId));

        return await _httpClient.GetReadAsAsync<RunStepResponse>(_endpointProvider.RunStepRetrieve(threadId, runId, stepId), cancellationToken);
    }
}