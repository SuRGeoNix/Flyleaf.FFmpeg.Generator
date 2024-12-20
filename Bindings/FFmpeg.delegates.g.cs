namespace Flyleaf.FFmpeg;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ConstCharPtrMarshaler))]
public unsafe delegate string AVClass_item_name (void* ctx);
public unsafe record struct AVClass_item_name_func(IntPtr Pointer)
{
    public static implicit operator AVClass_item_name_func(AVClass_item_name func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate AVClassCategory AVClass_get_category (void* ctx);
public unsafe record struct AVClass_get_category_func(IntPtr Pointer)
{
    public static implicit operator AVClass_get_category_func(AVClass_get_category func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVClass_query_ranges (AVOptionRanges** p0, void* obj, byte* key, int flags);
public unsafe record struct AVClass_query_ranges_func(IntPtr Pointer)
{
    public static implicit operator AVClass_query_ranges_func(AVClass_query_ranges func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void* AVClass_child_next (void* obj, void* prev);
public unsafe record struct AVClass_child_next_func(IntPtr Pointer)
{
    public static implicit operator AVClass_child_next_func(AVClass_child_next func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate AVClass* AVClass_child_class_iterate (void** iter);
public unsafe record struct AVClass_child_class_iterate_func(IntPtr Pointer)
{
    public static implicit operator AVClass_child_class_iterate_func(AVClass_child_class_iterate func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void av_log_set_callback_callback (void* p0, LogLevel p1, byte* p2, byte* p3);
public unsafe record struct av_log_set_callback_callback_func(IntPtr Pointer)
{
    public static implicit operator av_log_set_callback_callback_func(av_log_set_callback_callback func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void av_buffer_create_free (void* opaque, byte* data);
public unsafe record struct av_buffer_create_free_func(IntPtr Pointer)
{
    public static implicit operator av_buffer_create_free_func(av_buffer_create_free func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate AVBufferRef* av_buffer_pool_init_alloc (nuint size);
public unsafe record struct av_buffer_pool_init_alloc_func(IntPtr Pointer)
{
    public static implicit operator av_buffer_pool_init_alloc_func(av_buffer_pool_init_alloc func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate AVBufferRef* av_buffer_pool_init2_alloc (void* opaque, nuint size);
public unsafe record struct av_buffer_pool_init2_alloc_func(IntPtr Pointer)
{
    public static implicit operator av_buffer_pool_init2_alloc_func(av_buffer_pool_init2_alloc func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void av_buffer_pool_init2_pool_free (void* opaque);
public unsafe record struct av_buffer_pool_init2_pool_free_func(IntPtr Pointer)
{
    public static implicit operator av_buffer_pool_init2_pool_free_func(av_buffer_pool_init2_pool_free func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int av_tree_find_cmp (void* key, void* b);
public unsafe record struct av_tree_find_cmp_func(IntPtr Pointer)
{
    public static implicit operator av_tree_find_cmp_func(av_tree_find_cmp func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int av_tree_insert_cmp (void* key, void* b);
public unsafe record struct av_tree_insert_cmp_func(IntPtr Pointer)
{
    public static implicit operator av_tree_insert_cmp_func(av_tree_insert_cmp func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int av_tree_enumerate_cmp (void* opaque, void* elem);
public unsafe record struct av_tree_enumerate_cmp_func(IntPtr Pointer)
{
    public static implicit operator av_tree_enumerate_cmp_func(av_tree_enumerate_cmp func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int av_tree_enumerate_enu (void* opaque, void* elem);
public unsafe record struct av_tree_enumerate_enu_func(IntPtr Pointer)
{
    public static implicit operator av_tree_enumerate_enu_func(av_tree_enumerate_enu func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void AVHWDeviceContext_free (AVHWDeviceContext* ctx);
public unsafe record struct AVHWDeviceContext_free_func(IntPtr Pointer)
{
    public static implicit operator AVHWDeviceContext_free_func(AVHWDeviceContext_free func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void AVHWFramesContext_free (AVHWFramesContext* ctx);
public unsafe record struct AVHWFramesContext_free_func(IntPtr Pointer)
{
    public static implicit operator AVHWFramesContext_free_func(AVHWFramesContext_free func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void AVD3D11VADeviceContext_lock (void* lock_ctx);
public unsafe record struct AVD3D11VADeviceContext_lock_func(IntPtr Pointer)
{
    public static implicit operator AVD3D11VADeviceContext_lock_func(AVD3D11VADeviceContext_lock func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void AVD3D11VADeviceContext_unlock (void* lock_ctx);
public unsafe record struct AVD3D11VADeviceContext_unlock_func(IntPtr Pointer)
{
    public static implicit operator AVD3D11VADeviceContext_unlock_func(AVD3D11VADeviceContext_unlock func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void AVD3D12VADeviceContext_lock (void* lock_ctx);
public unsafe record struct AVD3D12VADeviceContext_lock_func(IntPtr Pointer)
{
    public static implicit operator AVD3D12VADeviceContext_lock_func(AVD3D12VADeviceContext_lock func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void AVD3D12VADeviceContext_unlock (void* lock_ctx);
public unsafe record struct AVD3D12VADeviceContext_unlock_func(IntPtr Pointer)
{
    public static implicit operator AVD3D12VADeviceContext_unlock_func(AVD3D12VADeviceContext_unlock func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void AVVulkanDeviceContext_lock_queue (AVHWDeviceContext* ctx, uint queue_family, uint index);
public unsafe record struct AVVulkanDeviceContext_lock_queue_func(IntPtr Pointer)
{
    public static implicit operator AVVulkanDeviceContext_lock_queue_func(AVVulkanDeviceContext_lock_queue func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void AVVulkanDeviceContext_unlock_queue (AVHWDeviceContext* ctx, uint queue_family, uint index);
public unsafe record struct AVVulkanDeviceContext_unlock_queue_func(IntPtr Pointer)
{
    public static implicit operator AVVulkanDeviceContext_unlock_queue_func(AVVulkanDeviceContext_unlock_queue func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void AVVulkanFramesContext_lock_frame (AVHWFramesContext* fc, AVVkFrame* vkf);
public unsafe record struct AVVulkanFramesContext_lock_frame_func(IntPtr Pointer)
{
    public static implicit operator AVVulkanFramesContext_lock_frame_func(AVVulkanFramesContext_lock_frame func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void AVVulkanFramesContext_unlock_frame (AVHWFramesContext* fc, AVVkFrame* vkf);
public unsafe record struct AVVulkanFramesContext_unlock_frame_func(IntPtr Pointer)
{
    public static implicit operator AVVulkanFramesContext_unlock_frame_func(AVVulkanFramesContext_unlock_frame func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void AVCodecContext_draw_horiz_band (AVCodecContext* s, AVFrame* src, ref int_array8 offset, int y, int type, int height);
public unsafe record struct AVCodecContext_draw_horiz_band_func(IntPtr Pointer)
{
    public static implicit operator AVCodecContext_draw_horiz_band_func(AVCodecContext_draw_horiz_band func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate AVPixelFormat AVCodecContext_get_format (AVCodecContext* s, AVPixelFormat* fmt);
public unsafe record struct AVCodecContext_get_format_func(IntPtr Pointer)
{
    public static implicit operator AVCodecContext_get_format_func(AVCodecContext_get_format func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVCodecContext_get_buffer2 (AVCodecContext* s, AVFrame* frame, int flags);
public unsafe record struct AVCodecContext_get_buffer2_func(IntPtr Pointer)
{
    public static implicit operator AVCodecContext_get_buffer2_func(AVCodecContext_get_buffer2 func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVCodecContext_execute (AVCodecContext* c, func_func func, void* arg2, int* ret, int count, int size);
public unsafe record struct AVCodecContext_execute_func(IntPtr Pointer)
{
    public static implicit operator AVCodecContext_execute_func(AVCodecContext_execute func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVCodecContext_execute2 (AVCodecContext* c, func_func func, void* arg2, int* ret, int count);
public unsafe record struct AVCodecContext_execute2_func(IntPtr Pointer)
{
    public static implicit operator AVCodecContext_execute2_func(AVCodecContext_execute2 func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVCodecContext_get_encode_buffer (AVCodecContext* s, AVPacket* pkt, int flags);
public unsafe record struct AVCodecContext_get_encode_buffer_func(IntPtr Pointer)
{
    public static implicit operator AVCodecContext_get_encode_buffer_func(AVCodecContext_get_encode_buffer func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVCodecParser_parser_init (AVCodecParserContext* s);
public unsafe record struct AVCodecParser_parser_init_func(IntPtr Pointer)
{
    public static implicit operator AVCodecParser_parser_init_func(AVCodecParser_parser_init func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVCodecParser_parser_parse (AVCodecParserContext* s, AVCodecContext* avctx, byte** poutbuf, int* poutbuf_size, byte* buf, int buf_size);
public unsafe record struct AVCodecParser_parser_parse_func(IntPtr Pointer)
{
    public static implicit operator AVCodecParser_parser_parse_func(AVCodecParser_parser_parse func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void AVCodecParser_parser_close (AVCodecParserContext* s);
public unsafe record struct AVCodecParser_parser_close_func(IntPtr Pointer)
{
    public static implicit operator AVCodecParser_parser_close_func(AVCodecParser_parser_close func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVCodecParser_split (AVCodecContext* avctx, byte* buf, int buf_size);
public unsafe record struct AVCodecParser_split_func(IntPtr Pointer)
{
    public static implicit operator AVCodecParser_split_func(AVCodecParser_split func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int avcodec_default_execute_func (AVCodecContext* c2, void* arg2);
public unsafe record struct avcodec_default_execute_func_func(IntPtr Pointer)
{
    public static implicit operator avcodec_default_execute_func_func(avcodec_default_execute_func func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int avcodec_default_execute2_func (AVCodecContext* c2, void* arg2, int p2, int p3);
public unsafe record struct avcodec_default_execute2_func_func(IntPtr Pointer)
{
    public static implicit operator avcodec_default_execute2_func_func(avcodec_default_execute2_func func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVIOContext_read_packet (void* opaque, byte* buf, int buf_size);
public unsafe record struct AVIOContext_read_packet_func(IntPtr Pointer)
{
    public static implicit operator AVIOContext_read_packet_func(AVIOContext_read_packet func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVIOContext_write_packet (void* opaque, byte* buf, int buf_size);
public unsafe record struct AVIOContext_write_packet_func(IntPtr Pointer)
{
    public static implicit operator AVIOContext_write_packet_func(AVIOContext_write_packet func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate long AVIOContext_seek (void* opaque, long offset, IOSeekFlags whence);
public unsafe record struct AVIOContext_seek_func(IntPtr Pointer)
{
    public static implicit operator AVIOContext_seek_func(AVIOContext_seek func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate CULong AVIOContext_update_checksum (CULong checksum, byte* buf, uint size);
public unsafe record struct AVIOContext_update_checksum_func(IntPtr Pointer)
{
    public static implicit operator AVIOContext_update_checksum_func(AVIOContext_update_checksum func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVIOContext_read_pause (void* opaque, int pause);
public unsafe record struct AVIOContext_read_pause_func(IntPtr Pointer)
{
    public static implicit operator AVIOContext_read_pause_func(AVIOContext_read_pause func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate long AVIOContext_read_seek (void* opaque, int stream_index, long timestamp, SeekFlags flags);
public unsafe record struct AVIOContext_read_seek_func(IntPtr Pointer)
{
    public static implicit operator AVIOContext_read_seek_func(AVIOContext_read_seek func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVIOContext_write_data_type (void* opaque, byte* buf, int buf_size, AVIODataMarkerType type, long time);
public unsafe record struct AVIOContext_write_data_type_func(IntPtr Pointer)
{
    public static implicit operator AVIOContext_write_data_type_func(AVIOContext_write_data_type func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVIOInterruptCB_callback (void* p0);
public unsafe record struct AVIOInterruptCB_callback_func(IntPtr Pointer)
{
    public static implicit operator AVIOInterruptCB_callback_func(AVIOInterruptCB_callback func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVFormatContext_control_message_cb (AVFormatContext* s, int type, void* data, nuint data_size);
public unsafe record struct AVFormatContext_control_message_cb_func(IntPtr Pointer)
{
    public static implicit operator AVFormatContext_control_message_cb_func(AVFormatContext_control_message_cb func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVFormatContext_io_open (AVFormatContext* s, AVIOContext** pb, byte* url, IOFlags flags, AVDictionary** options);
public unsafe record struct AVFormatContext_io_open_func(IntPtr Pointer)
{
    public static implicit operator AVFormatContext_io_open_func(AVFormatContext_io_open func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVFormatContext_io_close2 (AVFormatContext* s, AVIOContext* pb);
public unsafe record struct AVFormatContext_io_close2_func(IntPtr Pointer)
{
    public static implicit operator AVFormatContext_io_close2_func(AVFormatContext_io_close2 func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int avio_alloc_context_read_packet (void* opaque, byte* buf, int buf_size);
public unsafe record struct avio_alloc_context_read_packet_func(IntPtr Pointer)
{
    public static implicit operator avio_alloc_context_read_packet_func(avio_alloc_context_read_packet func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int avio_alloc_context_write_packet (void* opaque, byte* buf, int buf_size);
public unsafe record struct avio_alloc_context_write_packet_func(IntPtr Pointer)
{
    public static implicit operator avio_alloc_context_write_packet_func(avio_alloc_context_write_packet func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate long avio_alloc_context_seek (void* opaque, long offset, IOSeekFlags whence);
public unsafe record struct avio_alloc_context_seek_func(IntPtr Pointer)
{
    public static implicit operator avio_alloc_context_seek_func(avio_alloc_context_seek func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVFilter_preinit (AVFilterContext* ctx);
public unsafe record struct AVFilter_preinit_func(IntPtr Pointer)
{
    public static implicit operator AVFilter_preinit_func(AVFilter_preinit func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVFilter_init (AVFilterContext* ctx);
public unsafe record struct AVFilter_init_func(IntPtr Pointer)
{
    public static implicit operator AVFilter_init_func(AVFilter_init func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void AVFilter_uninit (AVFilterContext* ctx);
public unsafe record struct AVFilter_uninit_func(IntPtr Pointer)
{
    public static implicit operator AVFilter_uninit_func(AVFilter_uninit func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int _query_func (AVFilterContext* p0);
public unsafe record struct _query_func_func(IntPtr Pointer)
{
    public static implicit operator _query_func_func(_query_func func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int _query_func2 (AVFilterContext* p0, AVFilterFormatsConfig** cfg_in, AVFilterFormatsConfig** cfg_out);
public unsafe record struct _query_func2_func(IntPtr Pointer)
{
    public static implicit operator _query_func2_func(_query_func2 func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVFilter_process_command (AVFilterContext* p0, byte* cmd, byte* arg, byte* res, int res_len, int flags);
public unsafe record struct AVFilter_process_command_func(IntPtr Pointer)
{
    public static implicit operator AVFilter_process_command_func(AVFilter_process_command func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVFilter_activate (AVFilterContext* ctx);
public unsafe record struct AVFilter_activate_func(IntPtr Pointer)
{
    public static implicit operator AVFilter_activate_func(AVFilter_activate func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int func (AVFilterContext* ctx, void* arg, int jobnr, int nb_jobs);
public unsafe record struct func_func(IntPtr Pointer)
{
    public static implicit operator func_func(func func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int AVFilterGraph_execute (AVFilterContext* ctx, func_func func, void* arg, int* ret, int nb_jobs);
public unsafe record struct AVFilterGraph_execute_func(IntPtr Pointer)
{
    public static implicit operator AVFilterGraph_execute_func(AVFilterGraph_execute func) => new(func switch
    {
        null => IntPtr.Zero,
        _ => GetFunctionPointerForDelegate(func)
    });
}
