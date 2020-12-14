$('#collapse-navbar').on('show.bs.collapse', () => {
  $('.topCasaFina-banner').css('transform', 'translate(-50%, 10%)')
})

$('#collapse-navbar').on('hide.bs.collapse', () => {
  $('.topCasaFina-banner').css('transform', 'translate(-50%, -50%)')
})
