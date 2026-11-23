// Views rendered into docs/design/generated/ for the Design document.
// Per SysML2Tools syntax, 'expose' is only valid inside a named 'view' usage
// (not a 'view def' definition), and it - not 'render' - is what scopes the
// rendered diagram content.
package TemplateDotNetLibraryDesignViews {
    private import StandardViewDefinitions::*;
    private import TemplateDotNetLibrary::*;

    view SoftwareStructureView : InterconnectionView {
        expose TemplateDotNetLibrary::TemplateDotNetLibrarySystem;
    }

    view TemplateDotNetLibraryView {
        expose TemplateDotNetLibrarySystem;
    }
}
