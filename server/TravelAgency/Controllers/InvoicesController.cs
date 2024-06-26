﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.DTOs.InvoiceDTOs;
using TravelAgency.DTOs.PdfDTOs;
using TravelAgency.DTOs.UserDTOs;
using TravelAgency.Helpers;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice(InvoiceCreateDto dto)
        {
            try
            {
                UserTokenDto user = JwtHelper.GetCurrentUser(HttpContext.User);
                await _invoiceService.CreateInvoice(dto, user.Id, user.OrganizationId);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{contractId}/list")]
        public async Task<ActionResult> GetInvoicesByContractId(int contractId)
        {
            try
            {
                UserTokenDto user = JwtHelper.GetCurrentUser(HttpContext.User);
                var invoices = await _invoiceService.GetInvoicesByContract(contractId);
                return Ok(invoices);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}/generate")]
        public async Task<ActionResult<GenerateResponse>> GenerateDocument(int id)
        {
            try
            {
                var res = await _invoiceService.GenerateInvoicePdf(id);
                return File(res.File, "application/pdf", res.FileName);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
