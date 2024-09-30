 class Word:
    def __init__(self, text: str):
        self._text = text
        self._is_hidden = False

    def hide(self) -> None:
        self._is_hidden = True

    def show(self) -> None:
        self._is_hidden = False

    def is_hidden(self) -> bool:
        return self._is_hidden

    def get_display_text(self) -> str:
        return self._text if not self._is_hidden else "______"
